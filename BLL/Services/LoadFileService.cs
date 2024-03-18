using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Interfaces.Services;
using Interfaces.DTO;
using Interfaces.Repository;
using DomainModel;

namespace BLL.Services
{
    public class LoadFileService : ILoadFileService
    {
        private IDbRepos db;

        public LoadFileService(IDbRepos db)
        {
            this.db = db;
        }

        public void SaveProfitStatisticForRange(string filename, List<ReportAllTransactionsDto> reportData, string header, DateTime StDate, DateTime EndDate)
        {
            Document document = new Document();

            PdfWriter.GetInstance(document, new FileStream(filename, FileMode.Create));

            document.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
            Font fontH1 = new Font(baseFont, 16, Font.BOLD);
            Font fontH2 = new Font(baseFont, 14, Font.BOLD);
            Font fontComInf = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLDITALIC);

            Paragraph headerPDF = new Paragraph("Отчёт о финансовых результатах", fontH1);
            headerPDF.Capacity = 4;
            headerPDF.Alignment = Element.ALIGN_CENTER;
            document.Add(headerPDF);


            Paragraph headerRangeTime = new Paragraph($"За {StDate.ToShortDateString()} - {EndDate.ToShortDateString()}\n\n", fontH2);
            headerRangeTime.Capacity = 4;
            headerRangeTime.Alignment = Element.ALIGN_CENTER;

            document.Add(headerRangeTime);


            Paragraph org = new Paragraph("Организация ", font)
            {
                new Chunk("Магазин компьютерной техники \"VladPC\"", fontComInf)
            };

            org.SpacingAfter = 10;

            document.Add(org);


            Paragraph INN = new Paragraph()
            {
                new Chunk("Идентификационный номер налогоплательщика ", font),
                new Chunk("3712345678", fontComInf)
            };

            INN.SpacingAfter = 10;

            document.Add(INN);


            Paragraph EconAct = new Paragraph()
            {
                new Chunk("Вид экономической деятельности ", font),
                new Chunk("продажа электроники", fontComInf)
            };

            EconAct.SpacingAfter = 10;

            document.Add(EconAct);


            Paragraph form = new Paragraph()
            {
                new Chunk("Организационно-правовая форма / форма собственности\n", font),
                new Chunk("Индивидуальный предприниматель / Частная собственность", fontComInf),
            };

            form.SpacingAfter = 10;

            document.Add(form);


            Paragraph Rub = new Paragraph()
            {
                new Chunk("Единица измерения:    в руб.\n", font)
            };

            Rub.SpacingAfter = 20;

            document.Add(Rub);

            PdfPTable table = new PdfPTable(4);

            table.AddCell(new PdfPCell(new Phrase(new Phrase("№", font))));
            table.AddCell(new PdfPCell(new Phrase(new Phrase("Дата", font))));
            table.AddCell(new PdfPCell(new Phrase(new Phrase("Тип операции", font))));
            table.AddCell(new PdfPCell(new Phrase(new Phrase("Сумма", font))));
            //table.AddCell(new PdfPCell(new Phrase(new Phrase("Покупатель", font))));

            foreach (ReportAllTransactionsDto item in reportData)
            {
                table.AddCell(new Phrase(item.Id.ToString(), font));
                table.AddCell(new Phrase(item.CreatedDate.ToString(), font));
                table.AddCell(new Phrase(item.TypeTransaction, font));
                table.AddCell(new Phrase(item.Sum.ToString(), font));
            }

            table.AddCell(new Phrase("", font));
            table.AddCell(new Phrase("", font));
            table.AddCell(new Phrase("Чистая прибыль (убыток)", font));
            table.AddCell(new Phrase(reportData.Select(i => i.Sum).Sum().ToString(), font));

            document.Add(table);

            document.Close();
        }
    }
}
