using System.Windows;
using System;
using Ws.Renderer;
using Ws.Readers;
using Ws.Factories;

namespace Ws
{
    public partial class MainWindow : Window
    {
        private CanvasController _canvasController;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _canvasController = new CanvasController(this.MainCanvas);

                // Example format
                string format = "xml"; // Or determine format from user input or file extension
                var reader = ShapeReaderFactory.CreateShapeReader(format);
                var shapes = reader.ReadShapes("shapes." + format);

                var renderer = new ShapeRenderer(_canvasController);
                renderer.RenderShapes(shapes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading shapes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
