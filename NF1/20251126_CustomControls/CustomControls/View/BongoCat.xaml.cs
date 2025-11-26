using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
        private List<BitmapImage> imatges = new List<BitmapImage>();
        private int imageCounter = 0;

        //DispatcherTimer dispatcherTimer = new DispatcherTimer();
        bool filAlive = true;

        public BongoCat()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Precarreguem les imatges en memòria per agilitzar l'animació
        /// </summary>
        public void PrecarregaImatges()
        {
            for (int i = 1; i <= 38; i++)
            {
                BitmapImage imatge = new BitmapImage();
                imatge.BeginInit();
                String fileNumber =  i.ToString("0#");
                imatge.UriSource = new Uri("pack://application:,,,/resources/imagenes/terra_"+ fileNumber + ".png");
                imatge.EndInit();
                // Afegim la imatge a la llista
                imatges.Add(imatge);
            }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //dispatcherTimer.Interval = new TimeSpan(10000);
            //dispatcherTimer.Start();
            //dispatcherTimer.Tick += DispatcherTimer_Tick;

            PrecarregaImatges();

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
            rotacio.Angle += 1;
            imgTerra.Source = imatges[imageCounter];
            imageCounter = (imageCounter + 1) % imatges.Count;
        }

 
        private void Window_Closing(object? sender, CancelEventArgs e)
        {
            filAlive = false;
        }

    }
}
