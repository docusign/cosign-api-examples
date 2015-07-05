using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.IO;

namespace PDF_Annotation_Signature
{
    public partial class mainForm : Form
    {
        private const int MAX_LINES = 6;
        private const int CHARACTERS_PER_LINE = 35;
        private const int LINE_HEIGHT = 10;
        private const int SIGNATURE_FIELD_WIDTH = 146;
        private const int SIGNATURE_FIELD_HEIGHT = 50;

        public mainForm()
        {
            InitializeComponent();
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            string domain = string.IsNullOrWhiteSpace(textBoxDomain.Text) ? null : textBoxDomain.Text;
            string remarks = textBoxRemarks.Text.Trim(Environment.NewLine.ToCharArray());

            // Check validity of file path
            if (!File.Exists(textBoxPDF.Text))
            {
                MessageBox.Show("The file path is not valid...");
                return;
            }

            if (string.IsNullOrEmpty(remarks))
            {
                MessageBox.Show("Please enter your memo contents...");
                return;
            }

            try
            {
                int pageNum = validateAndRetrievePageNum(textBoxPDF.Text, textBoxPage.Text);
                int x = int.Parse(textBoxX.Text);
                int y = int.Parse(textBoxY.Text);

                // Simple algorithm to roughly calculate the number of lines in the memo
                int dummyLines = 0;
                foreach (string line in remarks.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    dummyLines += (int)(line.Length / CHARACTERS_PER_LINE) + 1;
                }

                int boxWidth = SIGNATURE_FIELD_WIDTH + 4;
                int boxHeight = dummyLines * LINE_HEIGHT + SIGNATURE_FIELD_HEIGHT + 10;

                // Add annotation to PDF
                addTextAnnotationToPDF(textBoxPDF.Text, remarks, pageNum, x, y, boxWidth, boxHeight);

                // Sign PDF (and place the signature field over the annotation)
                SAPIWrapper.SignPDF(textBoxPDF.Text, textBoxUsername.Text, domain, textBoxPassword.Text, pageNum, x + 2, y + 2, SIGNATURE_FIELD_WIDTH, SIGNATURE_FIELD_HEIGHT, textBoxTitle.Text.Trim());

                MessageBox.Show("The document has been successfully signed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error: {0}", ex.Message));
            }
        }

        private void buttonBrowsePDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF file (*.pdf)|*.pdf";
            ofd.Title = "Please select a PDF file";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxPDF.Text = ofd.FileName;
            }
        }

        // Add annotation to PDF using iTextSharp
        private void addTextAnnotationToPDF(string filePath, string contents, int pageNum, int x, int y, int width, int height)
        {
            PdfReader pdfReader = null;
            PdfStamper pdfStamp = null;

            try
            {
                using (var inStream = new FileStream(filePath, FileMode.Open))
                {
                    pdfReader = new PdfReader(inStream);
                }

                using (var outStream = new FileStream(filePath, FileMode.Create))
                {
                    pdfStamp = new PdfStamper(pdfReader, outStream, (char)0, true);

                    var rect = new iTextSharp.text.Rectangle((float)x, (float)y, (float)x + width, (float)y + height);

                    // Generating the annotation's appearance using a TextField
                    TextField textField = new TextField(pdfStamp.Writer, rect, null);
                    textField.Text = contents;
                    textField.FontSize = 8;
                    textField.TextColor = BaseColor.DARK_GRAY;
                    textField.BackgroundColor = new BaseColor(Color.LightGoldenrodYellow);
                    textField.BorderColor = new BaseColor(Color.BurlyWood);
                    textField.Options = TextField.MULTILINE;
                    textField.SetExtraMargin(2f, 2f);
                    textField.Alignment = Element.ALIGN_TOP | Element.ALIGN_LEFT;
                    PdfAppearance appearance = textField.GetAppearance();

                    // Create the annotation
                    PdfAnnotation annotation = PdfAnnotation.CreateFreeText(pdfStamp.Writer, rect, null, new PdfContentByte(null));
                    annotation.SetAppearance(PdfName.N, appearance);
                    annotation.Flags = PdfAnnotation.FLAGS_READONLY | PdfAnnotation.FLAGS_LOCKED | PdfAnnotation.FLAGS_PRINT;
                    annotation.Put(PdfName.NM, new PdfString(Guid.NewGuid().ToString()));

                    // Add annotation to PDF
                    pdfStamp.AddAnnotation(annotation, pageNum);
                    pdfStamp.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not add signature image to PDF with error: " + ex.Message);
            }
        }

        private void textBoxRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (textBoxRemarks.Lines.Length >= MAX_LINES)
                    e.Handled = true;
            }
        }

        private int validateAndRetrievePageNum(string filePath, string pageNumStr)
        {
            int pageNum = 0;
            if (!int.TryParse(pageNumStr, out pageNum))
                throw new Exception("Illegal page number");

            if (pageNum == 0 || pageNum < -2)
                throw new Exception("Illegal page number");

            int numOfPages = 0;
            using (var pdfReader = new PdfReader(filePath))
            {
                numOfPages = pdfReader.NumberOfPages;
            }

            if (pageNum > numOfPages)
                throw new Exception("Illegal page number");
            else if (pageNum == -1) // -1 indicates last page
                pageNum = numOfPages;
            else if (pageNum == -2) // -2 indicates penultimate page
                pageNum = numOfPages - 1;

            if (pageNum == 0)
                throw new Exception("Illegal page number");

            return pageNum;
        }
    }
}
