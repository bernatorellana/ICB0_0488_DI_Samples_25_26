using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CustomControls.View
{
    /// <summary>
    /// Lógica de interacción para BongoCat.xaml
    /// </summary>
    public partial class BongoCat : UserControl
    {

        //DispatcherTimer dispatcherTimer = new DispatcherTimer();
        bool filAlive = true;

        public BongoCat()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //dispatcherTimer.Interval = new TimeSpan(10000);
            //dispatcherTimer.Start();
            //dispatcherTimer.Tick += DispatcherTimer_Tick;

            Thread t = new Thread(DispatcherTimer_Tick);
            filAlive = true;
            t.Start();

            // Busquem la finestra on està el User Control (la finestra pare)
            // i ens subscrivim al seu event Closing
            Window window = Window.GetWindow(this);
            if (window != null)
            {
                window.Closing += Window_Closing; // Li indiquem el mètode que ha de cridar quan es tanca la finestra.
            }

        }



        private void DispatcherTimer_Tick()
        {
            while (filAlive)
            {
                // Accedim al fil d'intefície gràfica
                Dispatcher.Invoke(DispatcherPriority.Render,  modificaAngle);



               // imgTerra.Source = "/Resources/imágenes/terra_01.png";

                Thread.Sleep(100);
            }
        }
        //private void DispatcherTimer_Tick(object? sender, EventArgs e)
        //{
        //    rotacio.Angle += 1;
        //}

        // Aquesta funció modifica l'angle en el fil de UI
        private void modificaAngle()
        {
            rotacio.Angle += 3;
            BitmapImage imatge = new BitmapImage();
            imatge.BeginInit();
            imatge.UriSource = new Uri("pack://application:,,,/resources/imagenes/terra_11.png");
            imatge.EndInit();
            imgTerra.Source = imatge;
        }

 
        private void Window_Closing(object? sender, CancelEventArgs e)
        {
            filAlive = false;
        }

    }
}
