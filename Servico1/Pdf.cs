using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout.Properties;
using iText.Layout.Renderer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

using DocumentFormat.OpenXml.Wordprocessing;
using Border = iText.Layout.Borders.Border;
using Cell = iText.Layout.Element.Cell;
using Document = iText.Layout.Document;
using Form = System.Windows.Forms.Form;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using Paragraph = iText.Layout.Element.Paragraph;
using Rectangle = iText.Kernel.Geom.Rectangle;
using Table = iText.Layout.Element.Table;
using iText.Layout;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using iText.Layout.Layout;
using MySqlX.XDevAPI.Common;
using DocumentFormat.OpenXml.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using iText.StyledXmlParser.Jsoup.Nodes;
using DocumentFormat.OpenXml.Office2016.Excel;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using Control = System.Windows.Forms.Control;

namespace Servico1
{
    public partial class Pdf : Form
    {
        public Pdf()
        {
            InitializeComponent();

        }

        //----------------------------------------------- INSTRUÇÃO -----------------------------------------------
        //Para criar um pdf
        //                  - Instânciar o Pdf()
        //                  - Chamar as funções, em sequência. 
        //                  - adicionarLinhaNoList()
        //                  - setNumeroDaNota()
        //                  - setCamposCliente()            
        //                  - setValorTotal()
        //                  - criarPdf()

        private List<string[,]> listaDados = new List<string[,]>();
        private float reguladorZoom = 115;
        private string nomeCliente;
        private string docCliente;
        private string enderecoCliente;
        private string telCliente;
        private string numeroNota = "0";

        //--------------------------------------
        public double servico = 0;
        public double valorFinalParaDB = 0;
        //--------------------------------------

        FolderControl folder = new FolderControl();

        public string imgBrasao = @"..\..\Resources\logo2.jpg";

        Oficina of = new Oficina();
        OficinaDAO ofDAO = new OficinaDAO();
        //--------------------------------------

        
        private void Pdf_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.RoyalBlue;

            System.Drawing.Size size = this.Size;
            size.Width = size.Width - 130;
            axAcroPDF1.Size = size;

            //btnMais.Location.X = axAcroPDF1.Location.X + 10;
            lblZoom.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMais.Size.Width / 2) + 5, lblZoom.Size.Height - 6);
            btnMais.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMais.Size.Width / 2) + 5, btnMenos.Size.Height - 20);
            btnMenos.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMenos.Size.Width / 2) + 5, btnMenos.Size.Height * 2 - 20);
            label1.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMenos.Size.Width / 2) - 15, btnMenos.Size.Height * 3 - 15);
            picBoxPrint.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMenos.Size.Width / 2) + 5, btnMenos.Size.Height * 3 + 15);
            lblSalvar.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMenos.Size.Width / 2) - 10, btnMenos.Size.Height * 4 + 20);
            picBoxSalvar.Location = new System.Drawing.Point(axAcroPDF1.Width + (btnMenos.Size.Width / 2) + 5, btnMenos.Size.Height * 4 + 43);


            folder.createDir();

            //List<string[,]> lista = new List<string[,]>();
            //string[,] array = new string[1, 4];
            //array[0, 0] = "1";
            //array[0, 1] = "2";
            //array[0, 2] = "3";
            //array[0, 3] = "4";
            //lista.Add(array);

            //setNumeroNota(1.ToString());
            //setListaDados(lista);
            //criarPdfESalvaEMostra();
        }

        public void setCamposCliente(string nome, string doc, string end, string tel)
        {
            this.nomeCliente = nome;
            this.docCliente = doc;
            this.enderecoCliente = end;
            this.telCliente = tel;
        }

        public List<string[,]> getListaDados() { return listaDados; }

        public void setListaDados(List<string[,]> listaDados)
        {
            this.listaDados = listaDados;
        }
        public void adicionarLinhaNoList(string[,] linha)
        {
            listaDados.Add(linha);
        }

        public void criarPdfESalvaEMostra()
        {
            string filePathAndName = folder.createPdf();

            using (PdfWriter wPdf = new PdfWriter(filePathAndName))
            {
                if (listaDados.Count > 0) // listaDados.Count > 0 MUUUUDAAAARRRR PARA FUNCIONAR SEM O BOTÃO!!!!!!!!!!!!!!!
                {
                    //tabelaModeloSalvar(wPdf, getListaDados());

                    //MessageBox.Show(filePathAndName);

                    axAcroPDF1.src = folder.absolutePathOfPdf(filePathAndName);
                    axAcroPDF1.setShowScrollbars(true);
                    axAcroPDF1.setZoom(reguladorZoom);
                }
            }
        }


        public string criarPdfESalva()
        {
            string filePathAndName = folder.createPdf();

            return filePathAndName;
        }


        public void imprimiPdf(string filePathAndName)
        {
            //PdfWriter wPdf = new PdfWriter(filePathAndName);
            //AxAcroPDF ax = new AxAcroPDF();
            //ax.src = filePathAndName;
            //ax.Print();     
        }

        // Ao clicar REGISTRAR
        public void atualizaTabelaComCliente(string filePathAndName, string nomeCliente)
        {
            using (PdfWriter wPdf = new PdfWriter(filePathAndName))
            {
                ClientesDAO c = new ClientesDAO();
                List<Clientes> cliente = new List<Clientes>();

                cliente = c.procurarClientePeloNomeRetornLista(nomeCliente);

                setCamposCliente(cliente[0].NOME, cliente[0].DOC_PESSOAL, cliente[0].ENDERECO, cliente[0].CELULAR);

                numeroNota = cliente[0].N_NF.ToString();

                tabelaModeloSemLista(wPdf);
            }
        }
        public void mudaValorDiagnostico(string filePathAndName, List<string[,]> listaDados, string diag, string km, string nome, string doc, string end, string tel, string valorPago)
        {
            nomeCliente = nome;
            docCliente = doc;
            enderecoCliente = end;
            telCliente = tel;
            atualizaTabela(filePathAndName, listaDados, diag, km, valorPago);

        }

        //Ao clicar SALVAR
        public void atualizaTabela(string filePathAndName, List<string[,]> listaDados, string diag, string km, string valorPago)
        {
            using (PdfWriter wPdf = new PdfWriter(filePathAndName))
            {
                this.listaDados = listaDados;

                tabelaModeloSalvar(wPdf, listaDados, diag, km, valorPago);
            }
        }

        public void atualizaTabelaApenasNota()
        {
            //numeroNota = cliente[0].N_NF.ToString();
        }

        public void criaFolhaEmBranco(string filePathAndName)
        {
            using (PdfWriter wPdf = new PdfWriter(filePathAndName))
            {
                var pdfDocument = new PdfDocument(wPdf);
                var document = new Document(pdfDocument, PageSize.A4);
                document.Close();
                pdfDocument.Close();
            }
        }

        //Ao clicar FINALIZAR
        //public void finalizarTabela(int id, string filePathAndName, string diag, double km)
        //{
        //    using(PdfWriter wPdf = new PdfWriter(filePathAndName))
        //    {
        //        ClientesDAO c = new ClientesDAO();
        //        c.adicionarNumeroNota(id);
        //        numeroNota = c.buscaNumeroNota(id).ToString();
        //        tabelaModeloSalvar(wPdf, listaDados);
        //    }
        //}


        public void tabelaModeloSalvar(PdfWriter wPdf, List<string[,]> listaDados, string diagnostico, string valorKm, string valorPago)
        {
            var pdfDocument = new PdfDocument(wPdf);

            var document = new Document(pdfDocument, PageSize.A4);
            document.SetMargins(15, 15, 15, 15);
            
            //PAGINA INTEIRA

            float[] columnWidth = { 1, 3, 1 };



            //PRIMEIRA LINHA DE 10 ----------------------------------------
            
            Table tabela1 = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();

            Table tabelaArea1 = new Table(1).SetWidth(100);

            tabelaArea1.SetHorizontalAlignment(HorizontalAlignment.CENTER).SetBorder(Border.NO_BORDER);

            tabelaArea1.AddCell(new Cell()
                .Add(new Paragraph("Número da nota").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8))
                .Add(new Paragraph((Convert.ToInt32(numeroNota) + 1).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetBold()));

            tabelaArea1.AddCell(new Cell()
                .Add(new Paragraph("Dt e hora da emissão").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8))
                .Add(new Paragraph(DateTime.Now.ToString("dd-MM-yyyy HH:mm")).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8).SetBold()));

            tabelaArea1.AddCell(new Cell()
                .Add(new Paragraph("Código de verificação").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8))
                .Add(new Paragraph("cód").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetBold()));

            Image img = new Image(ImageDataFactory.Create(imgBrasao));

            tabela1.AddCell(new Cell().Add(img.SetAutoScale(true).SetWidth(UnitValue.CreatePercentValue(100))));

            tabela1.AddCell(new Cell().Add(new Paragraph(""
                    + "NOTA FISCAL DE SERVIÇO - NFSe")
                    .SetFontSize(14)
                    .SetPadding(8)
                    .SetFontColor(ColorConstants.BLACK)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));

            tabela1.AddCell(new Cell(1, 1).Add(tabelaArea1).SetVerticalAlignment(VerticalAlignment.MIDDLE));

            tabela1.SetNextRenderer(new TableBorderRenderer(tabela1));

            document.Add(tabela1);

            //SEGUNDA LINHA DE 10 ---------------------------------------------------------------

            float[] columnWidth2 = { 3, 2 };

            Table tabela2 = new Table(1).UseAllAvailableWidth();

            tabela2.AddCell(new Cell().Add(
                new Paragraph("PRESTADOR DE SERVIÇOS")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8)
                .SetBold())
                .SetBorder(Border.NO_BORDER)
                .SetMarginBottom(0)
                .SetPaddingBottom(0));

            Table tabelaArea2 = new Table(UnitValue.CreatePercentArray(columnWidth2)).UseAllAvailableWidth();

            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Nome/Razão social: BRAGA - MECANICA E SERVIÇOS MOVEIS").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Inscrição Municipal:MATRIZ").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("CPF/CNPJ:25.327.898/0001-38").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Endereço: Rua João Bento de Passos, Centro, 05").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Município: Borborema").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("UF:SP").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabela2.AddCell(new Cell().Add(tabelaArea2));

            tabela2.SetNextRenderer(new TableBorderRenderer(tabela2));

            document.Add(tabela2);

            //TERCEIRA LINHA DE 10 -------------------------------------------------------------------------------------------------


            float[] columnWidth3 = { 3, 2 };

            Table tabela3 = new Table(1).UseAllAvailableWidth();

            tabela3.AddCell(new Cell().Add(
                new Paragraph("TOMADOR DE SERVIÇOS")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8)
                .SetBold())
                .SetBorder(Border.NO_BORDER)
                .SetMarginBottom(0)
                .SetPaddingBottom(0));



            Table tabelaArea3 = new Table(UnitValue.CreatePercentArray(columnWidth2)).UseAllAvailableWidth();

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("Nome/Razão social: " + nomeCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("CPF/CNPJ: " + docCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("Endereço: " + enderecoCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("Telefone: " + telCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            //tabelaArea3.AddCell(new Cell()
            //    .Add(new Paragraph("E-mail: " ).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabela3.AddCell(new Cell().Add(tabelaArea3));

            tabela3.SetNextRenderer(new TableBorderRenderer(tabela3));

            document.Add(tabela3);

            //QUARTA LNHA DE 10 -------------------------------------------------------------------------------

            float[] columnWidth4 = { 20, 50, 6, 12, 12 };

            Table tabela4 = new Table(1).UseAllAvailableWidth();

            tabela4.AddCell(new Cell().Add(
                new Paragraph("DESCRIÇÃO DOS SERVIÇOS")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8)
                .SetBold())
                .SetMarginBottom(0)
                .SetPaddingBottom(0));

            Table tabelaArea4 = new Table(UnitValue.CreatePercentArray(columnWidth4)).SetHeight(500).UseAllAvailableWidth();

            Cell c1 = new Cell().SetPaddingTop(0);
            c1.Add(new Paragraph("Items").SetTextAlignment(TextAlignment.LEFT).SetFontSize(10));

            Cell c12 = new Cell().SetPaddingTop(0);
            c12.Add(new Paragraph("Descrição do serviço").SetTextAlignment(TextAlignment.LEFT).SetFontSize(10));

            Cell c2 = new Cell().SetPaddingTop(0);
            c2.Add(new Paragraph("Qtde").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

            Cell c3 = new Cell().SetPaddingTop(0);
            c3.Add(new Paragraph("Unitário").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

            Cell c4 = new Cell().SetPaddingTop(0);
            c4.Add(new Paragraph("Total").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

            Paragraph b = new Paragraph();
            
            servico = 0;
            double somatoria = 0;

            float getSetAltura = 0;

            for (int i = 0; i < listaDados.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0) 
                    {
                        Paragraph aux = new Paragraph();
                        aux.Add((" - " + listaDados[i].GetValue(0, j)).ToString())
                            .SetTextAlignment(TextAlignment.LEFT).SetFontSize(9)
                            .SetHorizontalAlignment(HorizontalAlignment.CENTER);
                        aux.SetMargin(0);

                        c1.Add(aux);
                    }
                    else if (j == 1) 
                    {
                        Paragraph aux = new Paragraph();
                        aux.Add((" - " + listaDados[i].GetValue(0, j)).ToString())
                            .SetTextAlignment(TextAlignment.LEFT).SetFontSize(9)
                            .SetHorizontalAlignment(HorizontalAlignment.CENTER);
                        aux.SetMargin(0);

                        c12.Add(aux);

                        //c12.Add(new Paragraph(" - " + listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.LEFT).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); 
                    }
                    else if (j == 2) { c2.Add(new Paragraph(listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
                    else if (j == 3) { c3.Add(new Paragraph("R$" + listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
                }
                    somatoria += Convert.ToDouble(listaDados[i].GetValue(0, 2)) * Convert.ToDouble(listaDados[i].GetValue(0, 3));
            }

            double valorTotal = somatoria;

            foreach (var array in listaDados)
            {
                servico += Convert.ToDouble(array[0, 3]);
            }


            valorFinalParaDB = valorTotal;

            c4.Add(new Paragraph("R$"+somatoria.ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8));

            //-------------------------------------------------------------------
            //int maxParagraphs = 0;
            //int maxLines = 0;

            //foreach (Paragraph paragraph in c1.GetChildren())
            //{
            //    IRenderer render = paragraph.CreateRendererSubTree();
            //    LayoutResult result = render.SetParent(document.GetRenderer()).Layout(new LayoutContext(new LayoutArea(1, new Rectangle(15, 15))));

            //    getSetAltura = result.GetOccupiedArea().GetBBox().GetHeight();
            //    result.GetOccupiedArea().SetBBox(new Rectangle(0,0,10,10)) ;
            //    render.GetNextRenderer();

            //    Run run = new Run();
            //    string texto = run.InnerText;
            //    paragraph.GetChildren(run);

            //    MessageBox.Show("texto: " + texto);
            //}
            //-------------------------------------------------------------------

            tabelaArea4.AddCell(c1);
            tabelaArea4.AddCell(c12);
            tabelaArea4.AddCell(c2);
            tabelaArea4.AddCell(c3);
            tabelaArea4.AddCell(c4);


            foreach (Cell cell in tabelaArea4.GetChildren())
            {
                
            }

            tabela4.AddCell(new Cell().Add(tabelaArea4));

            tabela4.SetNextRenderer(new TableBorderRenderer(tabela4));
            document.Add(tabela4);

            //QUINTA LINHA -----------------------------------------------------------------------------------------------------

            float[] columnWidth5 = { 20, 50, 6, 12, 12 };

            Table tabelaArea5 = new Table(UnitValue.CreatePercentArray(columnWidth5)).SetHeight(80).UseAllAvailableWidth();
            

            Table tabela5 = new Table(1).UseAllAvailableWidth();

            Cell c11 = new Cell().SetPadding(0);
            c11.Add(
                new Paragraph("ASSINATURA:")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10));
            
            Cell c111 = new Cell().SetPadding(0);
            c111.Add(
                new Paragraph("Valor total:"+"\nR$"+ valorFinalParaDB.ToString())
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(10));

            tabelaArea5.AddCell(c11);
            tabelaArea5.AddCell(new Cell());
            tabelaArea5.AddCell(new Cell());
            tabelaArea5.AddCell(new Cell());
            tabelaArea5.AddCell(c111);

            tabela5.AddCell(new Cell().Add(tabelaArea5));

            tabela5.SetNextRenderer(new TableBorderRenderer(tabela5));

            document.Add(tabela5);
            document.Add(tabela1);
            document.Add(tabela2);
            document.Add(tabela3);
            document.Add(tabela4);
            document.Add(tabela5);
            document.Close();
            pdfDocument.Close();

        }

        public void teste(Table table)
        {
            int maxParagraphs = 0;
            int maxLines = 0;
            
            foreach (Cell cell in table.GetChildren())
            {
                foreach (Paragraph paragraph in cell.GetChildren())
                {
                    int numLines = paragraph.GetChildren().Count();
                    maxLines = Math.Max(maxLines, numLines);
                    MessageBox.Show("numLines: " + numLines + "\n maxLines: " + maxLines);
                }
                int numParagraphs = cell.GetChildren().Count();
                maxParagraphs = Math.Max(maxParagraphs, numParagraphs);

                MessageBox.Show("numParagraphs: " + numParagraphs + "\n maxParagraphs: " + maxParagraphs);
            }
            
            //// Adicionar linhas vazias aos parágrafos para garantir que cada parágrafo tenha o mesmo número de linhas
            //foreach (TableRow row in table.Elements<TableRow>())
            //{
            //    foreach (TableCell cell in row.Elements<TableCell>())
            //    {
            //        foreach (Paragraph paragraph in cell.Elements<Paragraph>())
            //        {
            //            int numLines = paragraph.Descendants<Text>().Count();
            //            if (numLines < maxLines)
            //            {
            //                int numEmptyLines = maxLines - numLines;
            //                for (int i = 0; i < numEmptyLines; i++)
            //                {
            //                    Run run = new Run(new Text(""));
            //                    paragraph.AppendChild(run);
            //                }
            //            }
            //        }
            //    }
            //}

            //// Adicionar células vazias à linha para garantir que cada linha tenha o mesmo número de células
            //foreach (TableRow row in table.Elements<TableRow>())
            //{
            //    int numCells = row.Elements<TableCell>().Count();
            //    int numEmptyCells = maxParagraphs - numCells;
            //    if (numEmptyCells > 0)
            //    {
            //        for (int i = 0; i < numEmptyCells; i++)
            //        {
            //            TableCell emptyCell = new TableCell(new Paragraph(new Run(new Text(""))));
            //            row.AppendChild(emptyCell);
            //        }
            //    }
            //}

            //// Definir a propriedade de alinhamento das células para alinhar as células na tabela
            //foreach (TableCell cell in table.Descendants<TableCell>())
            //{
            //    TableCellProperties properties = cell.Elements<TableCellProperties>().FirstOrDefault();
            //    if (properties == null)
            //    {
            //        properties = new TableCellProperties();
            //        cell.AppendChild(properties);
            //    }
            //    Justification justification = properties.Elements<Justification>().FirstOrDefault();
            //    if (justification == null)
            //    {
            //        justification = new Justification();
            //        properties.AppendChild(justification);
            //    }
            //    justification.Val = Justification
            //        ValEnum.Center; // aqui você pode definir o alinhamento que deseja, como centralizado
            //}
        }

        public void tabelaModeloSemLista(PdfWriter wPdf)
        {
            var pdfDocument = new PdfDocument(wPdf);
            var document = new Document(pdfDocument, PageSize.A4);
            document.SetMargins(15, 15, 15, 15);

            //PAGINA INTEIRA

            float[] columnWidth = { 1, 3, 1 };

            Table tabela1 = new Table(UnitValue.CreatePercentArray(columnWidth)).UseAllAvailableWidth();


            //PRIMEIRA LINHA DE 10 ----------------------------------------


            Table tabelaArea1 = new Table(1).SetWidth(100);

            tabelaArea1.SetHorizontalAlignment(HorizontalAlignment.CENTER).SetBorder(Border.NO_BORDER);

            tabelaArea1.AddCell(new Cell()
                .Add(new Paragraph("Número da nota").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8))
                .Add(new Paragraph((Convert.ToInt32(numeroNota) + 1).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetBold()));


            tabelaArea1.AddCell(new Cell()
                .Add(new Paragraph("Dt e hora da emissão").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8))
                .Add(new Paragraph(DateTime.Now.ToString("dd-MM-yyyy HH:mm")).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8).SetBold()));

            tabelaArea1.AddCell(new Cell()
                .Add(new Paragraph("Código de verificação").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8))
                .Add(new Paragraph("cód").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10).SetBold()));

            Image img = new Image(ImageDataFactory.Create(imgBrasao));

            tabela1.AddCell(new Cell().Add(img.SetAutoScale(true).SetWidth(UnitValue.CreatePercentValue(100))));

            tabela1.AddCell(new Cell().Add(new Paragraph(""
                    + "NOTA FISCAL DE SERVIÇO - NFSe")
                    .SetFontSize(14)
                    .SetPadding(8)
                    .SetFontColor(ColorConstants.BLACK)
                    .SetBold()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER))
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE));

            tabela1.AddCell(new Cell(1, 1).Add(tabelaArea1).SetVerticalAlignment(VerticalAlignment.MIDDLE));

            tabela1.SetNextRenderer(new TableBorderRenderer(tabela1));

            document.Add(tabela1);

            //SEGUNDA LINHA DE 10 ---------------------------------------------------------------

            float[] columnWidth2 = { 3, 2 };

            Table tabela2 = new Table(1).UseAllAvailableWidth();

            tabela2.AddCell(new Cell().Add(
                new Paragraph("PRESTADOR DE SERVIÇOS")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8)
                .SetBold())
                .SetBorder(Border.NO_BORDER)
                .SetMarginBottom(0)
                .SetPaddingBottom(0));

            Table tabelaArea2 = new Table(UnitValue.CreatePercentArray(columnWidth2)).UseAllAvailableWidth();

            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Nome/Razão social: BRAGA - MECANICA E SERVIÇOS MOVEIS").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Inscrição Municipal:MATRIZ").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("CPF/CNPJ:25.327.898/0001-38").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Endereço: Rua João Bento de Passos, Centro, 05").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("Município: Borborema").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabelaArea2.AddCell(new Cell()
                .Add(new Paragraph("UF:SP").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));
            tabela2.AddCell(new Cell().Add(tabelaArea2));

            tabela2.SetNextRenderer(new TableBorderRenderer(tabela2));

            document.Add(tabela2);

            //TERCEIRA LINHA DE 10 -------------------------------------------------------------------------------------------------


            float[] columnWidth3 = { 3, 2 };

            Table tabela3 = new Table(1).UseAllAvailableWidth();

            tabela3.AddCell(new Cell().Add(
                new Paragraph("TOMADOR DE SERVIÇOS")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8)
                .SetBold())
                .SetBorder(Border.NO_BORDER)
                .SetMarginBottom(0)
                .SetPaddingBottom(0));



            Table tabelaArea3 = new Table(UnitValue.CreatePercentArray(columnWidth2)).UseAllAvailableWidth();

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("Nome/Razão social: " + nomeCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("CPF/CNPJ: " + docCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("Endereço: " + enderecoCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("")).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("Telefone: " + telCliente).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabelaArea3.AddCell(new Cell()
                .Add(new Paragraph("E-mail: ").SetTextAlignment(TextAlignment.LEFT).SetFontSize(8)).SetBorder(Border.NO_BORDER).SetPaddingTop(0));

            tabela3.AddCell(new Cell().Add(tabelaArea3));

            tabela3.SetNextRenderer(new TableBorderRenderer(tabela3));

            document.Add(tabela3);

            //QUARTA LNHA DE 10 -------------------------------------------------------------------------------


            float[] columnWidth4 = { 20, 50, 6, 12, 12 };

            Table tabela4 = new Table(1).UseAllAvailableWidth();

            tabela4.AddCell(new Cell().Add(
                new Paragraph("DESCRIÇÃO DOS SERVIÇOS")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(8)
                .SetBold())
                .SetMarginBottom(0)
                .SetPaddingBottom(0));

            Table tabelaArea4 = new Table(UnitValue.CreatePercentArray(columnWidth4)).SetHeight(525).UseAllAvailableWidth();

            //tabelaArea4.AddCell(new Cell()
            //    .Add(new Paragraph("Items").SetTextAlignment(TextAlignment.LEFT).SetFontSize(6))
            //    .SetPaddingTop(0));

            Cell c1 = new Cell().SetPaddingTop(0);
            c1.Add(new Paragraph("Items").SetTextAlignment(TextAlignment.LEFT).SetFontSize(10));

            Cell c12 = new Cell().SetPaddingTop(0);
            c12.Add(new Paragraph("Descrição do serviço").SetTextAlignment(TextAlignment.LEFT).SetFontSize(10));

            Cell c2 = new Cell().SetPaddingTop(0);
            c2.Add(new Paragraph("Qtde").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

            Cell c3 = new Cell().SetPaddingTop(0);
            c3.Add(new Paragraph("Unitário").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

            Cell c4 = new Cell().SetPaddingTop(0);
            c4.Add(new Paragraph("Total R$").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));

            //string[,] linhaNova = new string[listaDados.Count, 4];

            //for (int i = 0; i < listaDados.Count; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        if (j == 0) { c1.Add(new Paragraph(" - " + listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.LEFT).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
            //        else if (j == 1) { c12.Add(new Paragraph(" - " + listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.LEFT).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
            //        else if (j == 2) { c2.Add(new Paragraph(listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
            //        else if (j == 3) { c3.Add(new Paragraph("R$" + listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
            //        else if (j == 4) { c4.Add(new Paragraph("R$" + listaDados[i].GetValue(0, j).ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(9)).SetHorizontalAlignment(HorizontalAlignment.CENTER); }
            //    }
            //}

            //of = ofDAO.getOficinaValues();
            //kmTotal = kmTotal * of.VALOR_KM;
            //double diagEmValor = 0;
            //if(diag == "oficina") { diagEmValor = of.VALOR_DIAG_OFICINA; }
            //else if(diag == "socorro") { diagEmValor = of.VALOR_DIAG_FORA; }


            //c4.Add(new Paragraph(listaDados[0].GetValue(0, 2).ToString()).SetTextAlignment(TextAlignment.LEFT).SetFontSize(8));

            tabelaArea4.AddCell(c1);
            tabelaArea4.AddCell(c12);
            tabelaArea4.AddCell(c2);
            tabelaArea4.AddCell(c3);
            tabelaArea4.AddCell(c4);

            tabela4.AddCell(new Cell().Add(tabelaArea4));

            tabela4.SetNextRenderer(new TableBorderRenderer(tabela4));

            document.Add(tabela4);

            document.Close();
            pdfDocument.Close();

        }

        //Classe abaixo = Classe que criar uma bordar solida preta em uma tabela.
        private class TableBorderRenderer : TableRenderer
        {
            public TableBorderRenderer(Table modelElement)
                : base(modelElement)
            {
            }

            public override IRenderer GetNextRenderer()
            {
                return new TableBorderRenderer((Table)modelElement);
            }

            protected override void DrawBorders(DrawContext drawContext)
            {
                Rectangle rect = GetOccupiedAreaBBox();
                drawContext.GetCanvas()
                    .SaveState()
                    .Rectangle(rect.GetLeft(), rect.GetBottom(), rect.GetWidth(), rect.GetHeight())
                    .Stroke()
                    .RestoreState();
            }
        }
        private void zoomNoPdf(object sender)
        {
            Control c = sender as Control;
            string name = c.Name;

            if (reguladorZoom < 170)
            {
                if (name == "btnMais")
                {
                    reguladorZoom += 10;
                }
            }
            if (reguladorZoom > 50)
            {
                if (name == "btnMenos")
                {
                    reguladorZoom -= 10;
                }
            }

            axAcroPDF1.setZoom(reguladorZoom);
        }
        private void btnMais_Click(object sender, EventArgs e)
        {
            zoomNoPdf(sender);
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            zoomNoPdf(sender);
        }

        private void picBoxPrint_Click(object sender, EventArgs e)
        {
            FolderControl f = new FolderControl();
            imprimiPdf(f.pathForCurrentFile());
        }

        private void picBoxSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}
