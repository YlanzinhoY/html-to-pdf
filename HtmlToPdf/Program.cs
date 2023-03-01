using iText.Html2pdf;
using iText.Kernel.Pdf;
using System;
using System.IO;

namespace HtmlToPdfConverter {
    class Program {
        static void Main(string[] args) {
            try {
                if (args.Length == 0) {
                    Console.WriteLine("Por favor, especifique o arquivo HTML de entrada.");
                }

                string inputHtmlFile = Console.ReadLine();

                if (!File.Exists(inputHtmlFile)) {
                    Console.WriteLine("O arquivo HTML especificado não existe.");
                    return;
                }

                string outputPdfFile = Path.Combine(Path.GetDirectoryName(inputHtmlFile), Path.GetFileNameWithoutExtension(inputHtmlFile) + ".pdf");

                using (var htmlFileStream = File.OpenRead(inputHtmlFile)) {
                    using (var pdfFileStream = File.OpenWrite(outputPdfFile)) {
                        ConverterProperties converterProperties = new ConverterProperties();
                        HtmlConverter.ConvertToPdf(htmlFileStream, pdfFileStream, converterProperties);
                    }
                }

                Console.WriteLine("PDF criado com sucesso: " + outputPdfFile);
            }
            catch (Exception ex) {
                Console.WriteLine("Ocorreu um erro durante a conversão: " + ex.Message);
            }
        }
    }
}