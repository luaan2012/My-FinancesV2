using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Finances.CrossCutting.Helper
{
    public class VisaoDocs : IDisposable
    {
        private string CaminhoDocumento { get; set; }
        private string CaminhoDocumentoAssinado { get; set; }
        public VisaoDocs(string CaminhoDocumento, string CaminhoDocumentoAssinado)
        {
            this.CaminhoDocumento = CaminhoDocumento;
            this.CaminhoDocumentoAssinado = CaminhoDocumentoAssinado;
        }
        public class Posicao
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public enum TipoDadoEletronico
        {
            Texto,
            Imagem
        }
        public class Pagina
        {
            public int NumeroPagina { get; set; }
            public Posicao PosicaoPagina { get; set; }
            public Rectangle TamanhoPagina { get; set; }
        }
        public class AssinaturaEletronica
        {
            public Pagina[] Paginas { get; set; }
            public Stream StreamAssinatura { get; set; }
            public string Valor { get; set; }
            public TipoDadoEletronico TipoDadoEletronico { get; set; }
        }

        public void AssinarDocumento(params AssinaturaEletronica[] assinaturas)
        {
            using (FileStream fs = new FileStream(CaminhoDocumentoAssinado, FileMode.Create))
            {
                var reader = new PdfReader(CaminhoDocumento);
                var documento = new Document(reader.GetPageSize(1));
                var writer = PdfWriter.GetInstance(documento, fs);

                documento.Open();

                var contentByte = writer.DirectContent;

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    documento.SetPageSize(reader.GetPageSizeWithRotation(i));
                    //documento.NewPage();
                    var page = writer.GetImportedPage(reader, i);
                    var rotation = reader.GetPageRotation(i);
                    if (rotation == 90 || rotation == 270)
                        contentByte.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                    else
                        contentByte.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);

                    var assinaturasPagina = assinaturas.Where(x => x.Paginas.Any(p => p.NumeroPagina == i));

                    foreach (var assinatura in assinaturasPagina)
                    {
                        var pagina = assinatura.Paginas.FirstOrDefault(x => x.NumeroPagina == i);
                        if (assinatura.TipoDadoEletronico == TipoDadoEletronico.Imagem)
                        {
                            contentByte.BeginText();
                            var imagemAssinatura = Image.GetInstance(assinatura.StreamAssinatura);

                            imagemAssinatura.Alignment = Image.UNDERLYING;
                            imagemAssinatura.ScaleToFit(pagina.TamanhoPagina);
                            imagemAssinatura.SetAbsolutePosition(pagina.PosicaoPagina.X, pagina.PosicaoPagina.Y);

                            contentByte.AddImage(imagemAssinatura);
                            contentByte.EndText();
                        }
                        else if (assinatura.TipoDadoEletronico == TipoDadoEletronico.Texto)
                        {
                            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            contentByte.SetColorFill(BaseColor.DARK_GRAY);
                            contentByte.SetFontAndSize(bf, 8);
                            contentByte.BeginText();
                            contentByte.ShowTextAligned(Element.ALIGN_CENTER, assinatura.Valor, pagina.PosicaoPagina.X, pagina.PosicaoPagina.Y, 0);
                            contentByte.EndText();
                        }
                    }
                }

                documento.Close();
                fs.Close();
                writer.Close();
                reader.Close();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
