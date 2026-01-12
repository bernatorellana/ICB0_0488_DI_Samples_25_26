using PDFQuest.DataAdapter;
using PDFQuest.Template;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using System.IO;
using System.Windows.Media.Imaging;

namespace PDFQuest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnPDF_Click(object sender, RoutedEventArgs e)
        {

            await DescarregaPokemonAsync();

            QuestPDF.Settings.License = LicenseType.Community;

            var model = InvoiceDocumentDataSource.GetInvoiceDetails();
            var document = new InvoiceDocument(model);
            

            document.GeneratePdf("invoice.pdf");

            document.ShowInCompanionAsync();
            String path = Path.GetFullPath("invoice.pdf");

            BrowserView.Source = new Uri("file:///" + path);


        }

        private async Task DescarregaPokemonAsync()
        {
            await LoadImageAsync("https://www.pokemon.com/static-assets/content-assets/cms2/img/pokedex/full/001.png");
        }






    private static readonly HttpClient httpClient = new HttpClient();

    private async Task LoadImageAsync(string imageUrl)
    {
        try
        {
            
            
            String filePath = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1);
            DirectoryInfo di= Directory.CreateDirectory(@"Images");
            String fullPath = Path.Combine(di.FullName, filePath);
            if(!File.Exists(fullPath))
            {
                byte[] imageBytes = await httpClient.GetByteArrayAsync(imageUrl);
                await File.WriteAllBytesAsync(fullPath, imageBytes);
            } 
            /*else
            {
               MessageBox.Show("Imatge en cache");
            }*/
            

             /*
                 
            // Useu aquest codi per mostrar el bitmap en un <Image>
            //-----------------------------------------------------------
            using var ms = new MemoryStream(imageBytes);
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad; // important
            bitmap.StreamSource = ms;
            bitmap.EndInit();
            bitmap.Freeze(); // avoids threading issues
             */



            }
            catch (Exception ex)
        {
            // handle network / format / invalid URL errors
            MessageBox.Show(ex.Message);
        }
    }




    /*{
QuestPDF.Settings.License = LicenseType.Community;
// code in your main method
Document d = Document.Create(container =>
{
   container.Page(page =>
   {
       page.Size(PageSizes.A4);
       page.Margin(2, Unit.Centimetre);
       page.PageColor(QuestPDF.Helpers.Colors.White);
       page.DefaultTextStyle(x => x.FontSize(20));

       page.Header()
           .Text("Hello PDF!")
           .SemiBold().FontSize(36).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

       page.Content()
           .PaddingVertical(1, Unit.Centimetre)
           .Column(x =>
           {
               x.Spacing(20);

               x.Item().Text(Placeholders.LoremIpsum()).FontSize(12);
               x.Item().Text(Placeholders.LoremIpsum()).FontSize(12);
               x.Item().Image(Placeholders.Image(200, 100));
           });

       page.Footer()
           .AlignCenter()
           .Text(x =>
           {
               x.Span("Page ");
               x.CurrentPageNumber();
           });
   });
});//.GeneratePdfAndShow();

d.GeneratePdf("hello.pdf");

d.ShowInCompanionAsync();
String path = Path.GetFullPath("hello.pdf");

BrowserView.Source= new Uri("file:///"+path);



}*/
}
}