using PDFQuest.DataAdapter;
using PDFQuest.Template;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

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

        private void btnPDF_Click(object sender, RoutedEventArgs e)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var model = InvoiceDocumentDataSource.GetInvoiceDetails();
            var document = new InvoiceDocument(model);
            

            document.GeneratePdf("invoice.pdf");

            document.ShowInCompanionAsync();
            String path = Path.GetFullPath("invoice.pdf");

            BrowserView.Source = new Uri("file:///" + path);


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