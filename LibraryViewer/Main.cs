using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using OriginalCircuit.AltiumSharp;
using OriginalCircuit.AltiumSharp.BasicTypes;
using OriginalCircuit.AltiumSharp.Drawing;
using OriginalCircuit.AltiumSharp.Records;
using OpenMcdf;
using IComponent = OriginalCircuit.AltiumSharp.IComponent;
using IContainer = OriginalCircuit.AltiumSharp.IContainer;
using System.DirectoryServices.Protocols;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace LibraryViewer
{
    public partial class Main : Form
    {
        private bool _loading;
        private PropertyViewer _propertyViewer;
        private object _fileData;
        private Renderer _renderer;
        private bool _autoZoom;
        private Point _mouseLocation;
        private BufferedGraphics _graphicsBuffer;
        private bool _fastRendering;

        private IContainer _activeContainer;
        private IEnumerable<Primitive> _activePrimitives;
        private Unit _displayUnit;
        private Coord _snapGridSize;

        public Main()
        {
            InitializeComponent();

            pictureBox.MouseWheel += PictureBox_MouseWheel;
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, pictureBox, new object[] { true });
        }

        private SchLib GetAssetsSchLib()
        {
            using (var reader = new SchLibReader())
            {
                return reader.Read("assets.schlib");
            }
        }

        private void SetData(object fileData)
        {
            var saveLoading = _loading;
            _loading = true;
            try
            {
                SetActiveContainer(null);
                if (_propertyViewer != null)
                {
                    _propertyViewer.Close();
                    _propertyViewer = null;
                }

                IContainer container = null;


                gridSchLibComponents.Rows.Clear();

                Application.DoEvents();


                if (fileData is SchLib schLib)
                {
                    tabComponents.SelectTab(tabSchLib);

                    foreach (var component in schLib.Items)
                    {
                        var index = gridSchLibComponents.Rows.Add(component.LibReference, component.ComponentDescription);
                        gridSchLibComponents.Rows[index].Tag = component;
                    }

                    _displayUnit = schLib.Header.DisplayUnit;
                    _snapGridSize = schLib.Header.SnapGridSize;
                    _renderer = new SchLibRenderer(schLib.Header, GetAssetsSchLib());
                    container = schLib.Items.OfType<IContainer>().FirstOrDefault();
                }


                _fileData = fileData;
                SetActiveContainer(container);
            }
            finally
            {
                _loading = saveLoading;
            }
        }

        private void LoadFromFile(string fileName)
        {
            if (Path.GetExtension(fileName).Equals(".schlib", StringComparison.InvariantCultureIgnoreCase))
            {
                using (var reader = new SchLibReader())
                {
                    var data = reader.Read(fileName);
                    SetData(data);
                }
            }
        }

        private void SaveToFile(string fileName)
        {
            _loading = true;
            try
            {
                if (_fileData == null) return;

                if (_fileData is SchLib schLib)
                {
                    using (var writer = new SchLibWriter())
                    {
                        writer.Write(schLib, fileName, true);
                    }
                }

            }
            finally
            {
                _loading = false;
            }
        }

        private void LoadPrimitives(IContainer component)
        {
            if (component is SchComponent schComponent)
            {
                var pins = schComponent.GetPrimitivesOfType<SchPin>();
                foreach (var pin in pins)
                {
                    var i = gridSchLibPrimitives.Rows.Add(pin.Designator, pin.Name, pin.Electrical.ToString());
                    gridSchLibPrimitives.Rows[i].Tag = pin;
                }
            }
        }

        private void LoadTreeViewStructure(IContainer container)
        {
            void processContainer(TreeNodeCollection tnc, IContainer c)
            {
                foreach (var primitive in c.GetPrimitivesOfType<Primitive>(false))
                {
                    var node = tnc.Add(primitive.ToString());
                    node.Tag = primitive;

                    if (primitive is IContainer c2)
                    {
                        processContainer(node.Nodes, c2);
                    }
                }
            }

            //treeViewStructure.BeginUpdate();
            //processContainer(treeViewStructure.Nodes, container);
            //treeViewStructure.EndUpdate();
            //treeViewStructure.Refresh();
        }

        private void RequestRedraw(bool fastRendering)
        {
            _fastRendering = fastRendering;
            pictureBox.Invalidate();
            if (_fastRendering) pictureBox.Update();
        }

        private void Draw(Graphics target)
        {
            if (_activeContainer == null)
            {
                _renderer = null;
            }

            if (_renderer == null)
            {
                target.Clear(SystemColors.Control);
                return;
            }

            _renderer.Component = _activeContainer;
            if (_graphicsBuffer == null) _graphicsBuffer = BufferedGraphicsManager.Current.Allocate(CreateGraphics(), new Rectangle(0, 0, pictureBox.Width, pictureBox.Height));
            _renderer.Render(_graphicsBuffer.Graphics, pictureBox.Width, pictureBox.Height, _autoZoom, _fastRendering);
            _autoZoom = false;
            _graphicsBuffer.Render(target);

            if (_fastRendering)
            {
                redrawTimer.Stop();
                redrawTimer.Start();
            }
        }

        public void ExportStream(string inputFileName, string streamPath, string outputFileName)
        {
            using (var stream = new FileStream(inputFileName, FileMode.Open))
            using (var cf = new CompoundFile(stream))
            using (var ms = cf.GetStream(streamPath).GetMemoryStream())
            using (var fs = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            {
                ms.CopyTo(fs);
            }
        }

        private void ShowPropertyViewer(object[] items)
        {
            if (_propertyViewer == null)
            {
                _propertyViewer = new PropertyViewer();
                _propertyViewer.Owner = this;
                _propertyViewer.FormClosed += (s, a) => _propertyViewer = null;
                _propertyViewer.Changed += (s, a) => UpdateUi(false);
                _propertyViewer.Show(this);
            }
            _propertyViewer.SetSelectedObjects(items);
            _propertyViewer.BringToFront();
            _propertyViewer.Focus();
        }

        private void UpdateUi(bool autoZoom)
        {
            var saveLoading = _loading;
            try
            {
                _loading = true;
                _autoZoom = autoZoom;
                SetActiveContainer(_activeContainer, _activePrimitives);
            }
            finally
            {
                _loading = saveLoading;
            }
        }

        private void SetActiveContainer(IContainer component, IEnumerable<Primitive> activePrimitives = null)
        {
            if (_activeContainer != component)
            {
                _activeContainer = component;
                _autoZoom = true;

                panelPart.Visible = false;

                gridSchLibPrimitives.Rows.Clear();


                if (_activeContainer != null)
                {
                    LoadPrimitives(_activeContainer);
                    LoadTreeViewStructure(_activeContainer);
                }
            }
            else
            {

                gridSchLibPrimitives.Invalidate();

            }

            if (_activeContainer is SchComponent schComponent)
            {
                panelPart.Visible = (schComponent.DisplayModeCount > 1) || (schComponent.PartCount > 1);
                if (panelPart.Visible)
                {
                    comboDisplayMode.Items.Clear();
                    comboDisplayMode.Items.Add(@"Normal");
                    for (var i = 1; i < schComponent.DisplayModeCount; ++i)
                    {
                        comboDisplayMode.Items.Add($@"Alternate {i}");
                    }

                    comboDisplayMode.SelectedIndex = schComponent.DisplayMode;

                    editPart.Maximum = schComponent.PartCount;
                    labelPartTotal.Text = $@"of {editPart.Maximum}";
                    editPart.Value = schComponent.CurrentPartId;
                }
            }

            SetActivePrimitives(activePrimitives);
            if (_activeContainer != null && activePrimitives == null)
            {
                _propertyViewer?.SetSelectedObjects(new[] { _activeContainer });
            }

            RequestRedraw(false);
        }

        private void SetActivePrimitives(IEnumerable<Primitive> primitives)
        {
            if (_activePrimitives != primitives)
            {
                _activePrimitives = primitives;
                _propertyViewer?.SetSelectedObjects(_activePrimitives?.ToArray());

                if (_renderer == null) return;
                _renderer.SelectedPrimitives = _activePrimitives;
                RequestRedraw(false);
            }
        }



        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(saveFileDialog.FileName);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void GridSchLibComponents_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || gridSchLibComponents.SelectedRows.Count == 0) return;

            var container = (IContainer)gridSchLibComponents.Rows[gridSchLibComponents.SelectedRows[0].Index].Tag;
            SetActiveContainer(container);
        }

        private void GridComponents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_activeContainer == null) return;
            ShowPropertyViewer(new[] { _activeContainer });
        }




        private void GridSchLibPrimitives_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_loading || gridSchLibPrimitives.SelectedRows.Count == 0) return;

            var primitives = gridSchLibPrimitives.SelectedRows.OfType<DataGridViewRow>()
                .Select(row => (SchPrimitive)row.Tag).ToArray();
            SetActivePrimitives(primitives);
        }

        private void gridSchLibPrimitives_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (_loading || e.RowIndex < 0) return;

            // Draw background depending on the "display mode" matching the current one
            var primitive = (SchPrimitive)gridSchLibPrimitives.Rows[e.RowIndex].Tag;
            if (!primitive.IsOfCurrentDisplayMode)
            {
                e.PaintCellsBackground(e.RowBounds, (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected);
                using (var brush = new HatchBrush(HatchStyle.DiagonalCross, Color.FromKnownColor(KnownColor.ControlDark), Color.Transparent))
                {
                    e.Graphics.FillRectangle(brush, e.RowBounds);
                }

                // Draw contents
                e.PaintCellsContent(e.RowBounds);
                e.Handled = true;
            }
        }

        private void comboDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            if (_activeContainer is SchComponent c)
            {
                c.DisplayMode = comboDisplayMode.SelectedIndex;
            }
            UpdateUi(true);
        }

        private void editPart_ValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            if (_activeContainer is SchComponent c)
            {
                c.CurrentPartId = (int)editPart.Value;
            }
            UpdateUi(true);
        }

        private void GridPrimitives_DoubleClick(object sender, EventArgs e)
        {
            if (_activePrimitives?.Any() == false) return;

            ShowPropertyViewer(_activePrimitives?.ToArray());
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _autoZoom = true;
            RequestRedraw(false);
        }

        private void ZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_renderer == null) return;

            var zoom = Convert.ToDouble(((ToolStripMenuItem)sender).Tag) / 100.0;
            _renderer.Zoom = zoom;

            _autoZoom = false;
            RequestRedraw(false);
        }

        private void ExportFootprintToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_activeContainer == null) return;

            var container = _activeContainer;
            string streamPath;
            if (container is IComponent component)
            {
                streamPath = $"{component.Name.Replace('/', '_')}/Data";
            }
            else
            {
                streamPath = "FileHeader";
            }
            saveFileDialog.FileName = streamPath.Replace('/', '_') + ".bin";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportStream(openFileDialog.FileName, streamPath, saveFileDialog.FileName);
            }
        }

        private void ExportPrimitiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_activeContainer == null || (_activePrimitives?.Count() != 1)) return;

            var container = _activeContainer;
            var primitive = _activePrimitives.First();
            if (container is PcbComponent pcbComponent)
            {
                var pcbPrimitive = primitive as PcbPrimitive;
                var primitiveIndex = pcbComponent.Primitives.IndexOf(pcbPrimitive);
                saveFileDialog.FileName = $"pcb_{pcbComponent.Pattern}_{primitiveIndex}_{pcbPrimitive.GetDisplayInfo().Name}.bin".Replace('/', '_');
            }
            else if (container is SchComponent schComponent)
            {
                var schPrimitive = primitive as SchPrimitive;
                var primitiveId = schPrimitive.GetHashCode();
                saveFileDialog.FileName = $"sch_{schComponent.LibReference}_{primitiveId}_{schPrimitive.Record}.bin".Replace('/', '_');
            }
            else
            {
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllBytes(saveFileDialog.FileName, primitive.RawData.ToArray());
            }
        }

        private void ExportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_activeContainer == null || _graphicsBuffer == null) return;

            saveFileDialog.FileName = Path.ChangeExtension(openFileDialog.FileName, ".png");

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (var bitmap = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height))
                using (var target = Graphics.FromImage(bitmap))
                {
                    Draw(target);
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        private void PictureBox_Resize(object sender, EventArgs e)
        {
            _graphicsBuffer?.Dispose();
            _graphicsBuffer = null;

            if (_activeContainer != null)
            {
                RequestRedraw(false);
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                SetActivePrimitives(_renderer?.Pick(e.X, e.Y));
            }
        }

        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_activePrimitives?.Count() > 0)
            {
                ShowPropertyViewer(_activePrimitives.ToArray());
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_activeContainer == null) return;

            if (e.Button == MouseButtons.Right && !_mouseLocation.IsEmpty)
            {
                pictureBox.Cursor = Cursors.Hand;
                var dX = e.X - _mouseLocation.X;
                var dY = e.Y - _mouseLocation.Y;
                if (dX != 0 || dY != 0)
                {
                    _renderer.Pan(dX, dY);
                    RequestRedraw(true);
                }
            }
            else
            {
                pictureBox.Cursor = Cursors.Default;
            }

            var location = _renderer.WorldFromScreen(new PointF(e.Location.X, e.Location.Y));
            statusLocation.Text = $"{location.ToString(_displayUnit, _snapGridSize)}    Grid: {_snapGridSize.ToString(_displayUnit)}";

            _mouseLocation = e.Location;
            pictureBox.Focus();
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (_activeContainer != null)
            {
                var scaleFactor = ModifierKeys.HasFlag(Keys.Control) ? 1e-4 : 1e-3;
                _renderer.Scale *= 1.0f + (e.Delta * scaleFactor);
                RequestRedraw(true);
            }
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void RedrawTimer_Tick(object sender, EventArgs e)
        {
            if (_activeContainer != null)
            {
                RequestRedraw(false);
            }
            redrawTimer.Enabled = false;
        }

        private void treeViewStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var primitive = (Primitive)e.Node.Tag;
            IEnumerable<Primitive> primitives = new[] { primitive };
            if (primitive is IContainer container)
            {
                primitives = Enumerable.Concat(primitives, container.GetPrimitivesOfType<Primitive>());
            }
            SetActivePrimitives(primitives);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetActiveContainer(null);

            var schLib = new SchLib
            {
                new SchComponent
                {
                    new SchRectangle { Corner = CoordPoint.FromMils(500, 1100) },
                    new SchPin { Location = CoordPoint.FromMils(500, 100) },
                    new SchPin { Location = CoordPoint.FromMils(500, 250) },
                    new SchPin { Location = CoordPoint.FromMils(500, 400) },
                    new SchPin { Location = CoordPoint.FromMils(500, 550) },
                    new SchPin { Location = CoordPoint.FromMils(500, 700) },
                    new SchPin { Location = CoordPoint.FromMils(500, 850) },
                    new SchPin { Location = CoordPoint.FromMils(500, 1000) },
                    new SchPin { Designator = "P8", Location = CoordPoint.FromMils(0, 1000), Orientation = TextOrientations.Flipped },
                    new SchPin { Location = CoordPoint.FromMils(0, 850), Orientation = TextOrientations.Flipped },
                    new SchPin { Location = CoordPoint.FromMils(0, 700), Orientation = TextOrientations.Flipped },
                    new SchPin { Location = CoordPoint.FromMils(0, 550), Orientation = TextOrientations.Flipped },
                    new SchPin { Location = CoordPoint.FromMils(0, 400), Orientation = TextOrientations.Flipped },
                    new SchPin { Location = CoordPoint.FromMils(0, 250), Orientation = TextOrientations.Flipped },
                    new SchPin { Location = CoordPoint.FromMils(0, 100), Orientation = TextOrientations.Flipped }
                }
            };
            SetData(schLib);
        }




        private void openiocFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.CheckFileExists = true;
                fileDialog.Filter = @"STM32CubeMX file (*.ioc)|*.ioc";
                if (fileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }


                STM32CubeMX_Parser conf = new STM32CubeMX_Parser(fileDialog.FileNames[0]);

                string symbolPath = Application.StartupPath + "footprints";
                string[] footprints = Directory.GetFiles(symbolPath);

                string footprintPath = Array.Find(footprints, element => element.Contains(conf.MCU.name, StringComparison.OrdinalIgnoreCase));

                if (footprintPath != null)
                {
                    LoadFromFile(footprintPath);
                    updatePins();
                    updateFootprint(conf);
                }
                else
                {
                    MessageBox.Show("Can't locate footprint File: " + conf.MCU.name, "Finding Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void updatePins()
        {
            Regex rg = new Regex(@"^P[A-Z]\d+");

            if (_fileData is SchLib schLib)
            {
                SchComponent component = schLib.Items[0];
                foreach (var item in component)
                {
                    if (item is SchPin Componentpin)
                    {
                        if (rg.IsMatch(Componentpin.Name))
                        {
                            Componentpin.Name = rg.Match(Componentpin.Name).Value;
                        }
                    }
                }
            }


        }

        private void updateFootprint(STM32CubeMX_Parser conf)
        {
            List<STM32CubeMX_Parser.PinsParams> MXpins = conf.Pins;

            if (_fileData is SchLib schLib)
            {
                SchComponent component = schLib.Items[0];
                component.TargetFileName = conf.MCU.CPN;
                component.Comment.Text = conf.MCU.CPN;   

                foreach (var item in component)
                {
                    if (item is SchPin Componentpin)
                    {
                        STM32CubeMX_Parser.PinsParams MXpin;

                        MXpin = MXpins.Find(x => x.name == Componentpin.Name);
                        if(MXpin.signal != null)
                        {
                            if (MXpin.label != null)
                            {
                                Componentpin.Name += " / " + MXpin.label;
                                Componentpin.Description = MXpin.mode + ">>" + MXpin.signal;
                                
                            }
                            else
                            {
                                Componentpin.Name += " / " + MXpin.signal;
                                Componentpin.Description = MXpin.mode;
                            }
                            
                            
                            Componentpin.Color = Color.DarkBlue;
                        }
                    }
                }
            }
        }

 
    }
}
