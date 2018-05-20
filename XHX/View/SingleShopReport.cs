using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XHX.DTO.SingleShopReport;
using XHX.DTO;
using XHX.Common;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Threading;

namespace XHX.View
{
    public partial class SingleShopReport : BaseForm
    {
        public static localhost.Service service = new localhost.Service();
        //LocalService service = new LocalService();
        MSExcelUtil msExcelUtil = new MSExcelUtil();
        List<ShopDto> shopList = new List<ShopDto>();
        List<ShopDto> shopLeft = new List<ShopDto>();
        public List<ShopDto> ShopList
        {
            get { return shopList; }
            set { shopList = value; }
        }
        GridCheckMarksSelection selection;
        internal GridCheckMarksSelection Selection
        {
            get
            {
                return selection;
            }
        }
        public SingleShopReport()
        {
            InitializeComponent();
            XHX.Common.BindComBox.BindProject(cboProjects);
            tbnFilePath.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            btnModule.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            SearchAllShopByProjectCode(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
            CommonHandler.SetRowNumberIndicator(gridView1);
            selection = new GridCheckMarksSelection(gridView1);
            selection.CheckMarkColumn.VisibleIndex = 0;
        }

        public override List<BaseForm.ButtonType> CreateButton()
        {
            List<XHX.BaseForm.ButtonType> list = new List<XHX.BaseForm.ButtonType>();
            return list;
        }

        private List<ShopDto> SearchAllShopByProjectCode(string projectCode)
        {
            DataSet ds = service.SearchShopByProjectCode(projectCode);
            List<ShopDto> shopDtoList = new List<ShopDto>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ShopDto shopDto = new ShopDto();
                    shopDto.ShopCode = Convert.ToString(ds.Tables[0].Rows[i]["ShopCode"]);
                    shopDto.ShopName = Convert.ToString(ds.Tables[0].Rows[i]["ShopName"]);
                    shopDtoList.Add(shopDto);
                }
            }
            grcShop.DataSource = shopDtoList;
            return shopDtoList;
        }

        private ShopReportDto GetShopReportDto(string projectCode, string shopCode)
        {
            DataSet[] dataSetList = service.GetShopReportDto(projectCode, shopCode);
            ShopReportDto shopReportDto = new ShopReportDto();
            List<ShopCharterScoreInfoDto> shopCharterScoreInfoDtoList = new List<ShopCharterScoreInfoDto>();
            List<ShopSubjectScoreInfoDto> shopSubjectScoreInfoDtoList = new List<ShopSubjectScoreInfoDto>();

            List<SaleContantScoreInfoDto> saleContantScoreInfoList = new List<SaleContantScoreInfoDto>();
            List<SaleContantSubjectScoreDto> saleContantSubjectScoreDtoList = new List<SaleContantSubjectScoreDto>();

            shopReportDto.SaleContantScoreInfoList = saleContantScoreInfoList;
            shopReportDto.SaleContantSubjectScoreDtoList = saleContantSubjectScoreDtoList;
            shopReportDto.ShopCharterScoreInfoDtoList = shopCharterScoreInfoDtoList;
            shopReportDto.ShopSubjectScoreInfoDtoList = shopSubjectScoreInfoDtoList;

            #region 经销商基本信息
            DataSet dsShop = dataSetList[0];
            if (dsShop.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsShop.Tables[0].Rows.Count; i++)
                {
                    shopReportDto.ShopCode = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopCode"]);
                    shopReportDto.ShopName = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopName"]);
                    shopReportDto.AreaName = Convert.ToString(dsShop.Tables[0].Rows[i]["AreaCode"]);
                    shopReportDto.City = Convert.ToString(dsShop.Tables[0].Rows[i]["City"]);
                    shopReportDto.ShopScore = Convert.ToString(dsShop.Tables[0].Rows[i]["ShopScore"]);
                    shopReportDto.OrderNO_All = Convert.ToString(dsShop.Tables[0].Rows[i]["OrderNO_All"]);
                    shopReportDto.OrderNO_Area = Convert.ToString(dsShop.Tables[0].Rows[i]["OrderNO_SmallArea"]);
                    shopReportDto.SalesContant = Convert.ToString(dsShop.Tables[0].Rows[i]["SaleContant"]);
                    shopReportDto.SmallAreaScore = Convert.ToString(dsShop.Tables[0].Rows[i]["SmallScore"]);
                    shopReportDto.BigAreaScore = Convert.ToString(dsShop.Tables[0].Rows[i]["BigScore"]);
                    shopReportDto.AllScore = Convert.ToString(dsShop.Tables[0].Rows[i]["AllScore"]);
                    shopReportDto.MustLoss = Convert.ToString(dsShop.Tables[0].Rows[i]["MustLoss"]);
                }
            }
            #endregion
            #region 章节信息
            DataSet dsCharter = dataSetList[1];
            if (dsCharter.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsCharter.Tables[0].Rows.Count; i++)
                {
                    ShopCharterScoreInfoDto shopCharterScoreInfo = new ShopCharterScoreInfoDto();
                    shopCharterScoreInfo.CharterCode = Convert.ToString(dsCharter.Tables[0].Rows[i]["CharterCode"]);
                    shopCharterScoreInfo.ShopScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["ShopCharterScore"]);
                    shopCharterScoreInfo.SmallScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["SmallCharterScore"]);
                    shopCharterScoreInfo.BigScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["BigCharterScore"]);
                    shopCharterScoreInfo.AllScore = Convert.ToString(dsCharter.Tables[0].Rows[i]["AllCharterScore"]);
                    shopCharterScoreInfoDtoList.Add(shopCharterScoreInfo);
                }
            }
            #endregion
            #region 体系信息
            DataSet dsSubject = dataSetList[2];
            if (dsSubject.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSubject.Tables[0].Rows.Count; i++)
                {
                    ShopSubjectScoreInfoDto shopSubjectScoreInfo = new ShopSubjectScoreInfoDto();
                    shopSubjectScoreInfo.SubjectCode = Convert.ToString(dsSubject.Tables[0].Rows[i]["SubjectCode"]);
                    shopSubjectScoreInfo.CheckPoint = Convert.ToString(dsSubject.Tables[0].Rows[i]["CheckPoint"]);
                    shopSubjectScoreInfo.Score = Convert.ToString(dsSubject.Tables[0].Rows[i]["Score"]);
                    shopSubjectScoreInfo.LossDesc = Convert.ToString(dsSubject.Tables[0].Rows[i]["LossDesc"]);
                    shopSubjectScoreInfo.Remark = Convert.ToString(dsSubject.Tables[0].Rows[i]["Remark"]);
                    shopSubjectScoreInfoDtoList.Add(shopSubjectScoreInfo);
                }
            }
            #endregion
            #region 销售顾问

            DataSet dsSaleContantInfo = dataSetList[3];
            if (dsSaleContantInfo.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSaleContantInfo.Tables[0].Rows.Count; i++)
                {
                    SaleContantScoreInfoDto saleContantScoreInfo = new SaleContantScoreInfoDto();
                    saleContantScoreInfo.SaleName = Convert.ToString(dsSaleContantInfo.Tables[0].Rows[i]["SaleName"]);
                    //saleContantScoreInfo.Score = Convert.ToString(dsSaleContantInfo.Tables[0].Rows[i]["Score"]);

                    saleContantScoreInfoList.Add(saleContantScoreInfo);
                }
            }
            DataSet dsSaleSubjectScoreInfo = dataSetList[4];
            if (dsSaleSubjectScoreInfo.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSaleSubjectScoreInfo.Tables[0].Rows.Count; i++)
                {
                    SaleContantSubjectScoreDto saleSubjectSore = new SaleContantSubjectScoreDto();
                    saleSubjectSore.SubjectCode = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["SubjectCode"]);
                    saleSubjectSore.SaleName = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["SalesConsultant"]);
                    saleSubjectSore.Score = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["Score"]);
                    saleSubjectSore.Remark = Convert.ToString(dsSaleSubjectScoreInfo.Tables[0].Rows[i]["Remark"]);

                    saleContantSubjectScoreDtoList.Add(saleSubjectSore);
                }
            }
            #endregion
            return shopReportDto;
        }

        private void WriteDataToExcel(ShopReportDto shopReportDto)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(tbnFilePath.Text + @"\" + "Smart销售质量现场考核报告模板.xlsx");

            #region 经销商基本信息
            {
                Worksheet worksheet_FengMian = workbook.Worksheets["本店总分"] as Worksheet;
                #region 经销商基本信息
                msExcelUtil.SetCellValue(worksheet_FengMian, "D11", shopReportDto.ShopName);
                msExcelUtil.SetCellValue(worksheet_FengMian, "J13", shopReportDto.AreaName);
                msExcelUtil.SetCellValue(worksheet_FengMian, "D13", shopReportDto.ShopCode);
                //msExcelUtil.SetCellValue(worksheet_FengMian, "J14", shopReportDto.SalesContant);

                msExcelUtil.SetCellValue(worksheet_FengMian, "G22", shopReportDto.ShopScore);
                msExcelUtil.SetCellValue(worksheet_FengMian, "H22", shopReportDto.SmallAreaScore);
                msExcelUtil.SetCellValue(worksheet_FengMian, "I22", shopReportDto.BigAreaScore);
                msExcelUtil.SetCellValue(worksheet_FengMian, "J22", shopReportDto.AllScore);

                msExcelUtil.SetCellValue(worksheet_FengMian, "G23", shopReportDto.OrderNO_All);
                msExcelUtil.SetCellValue(worksheet_FengMian, "G24", shopReportDto.OrderNO_Area);

                // msExcelUtil.SetCellValue(worksheet_FengMian, "G30", shopReportDto.MustLoss);
                #endregion
                #region 章节信息
                for (int i = 23; i < 32; i++)
                {
                    for (int j = 0; j < shopReportDto.ShopCharterScoreInfoDtoList.Count; j++)
                    {
                        if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopCharterScoreInfoDtoList[j].CharterCode)
                        {
                            msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopCharterScoreInfoDtoList[j].ShopScore);
                            msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, shopReportDto.ShopCharterScoreInfoDtoList[j].SmallScore);
                            msExcelUtil.SetCellValue(worksheet_FengMian, "I", i, shopReportDto.ShopCharterScoreInfoDtoList[j].BigScore);
                            msExcelUtil.SetCellValue(worksheet_FengMian, "J", i, shopReportDto.ShopCharterScoreInfoDtoList[j].AllScore);
                        }
                    }
                }

                #endregion
                #region 体系信息
                for (int i = 56; i < 172; i++)
                {
                    for (int j = 0; j < shopReportDto.ShopSubjectScoreInfoDtoList.Count; j++)
                    {
                        if (msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == shopReportDto.ShopSubjectScoreInfoDtoList[j].SubjectCode)
                        {
                            msExcelUtil.SetCellValue(worksheet_FengMian, "G", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Score);
                            msExcelUtil.SetCellValue(worksheet_FengMian, "H", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc);
                            if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 34)
                                msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 45);
                            if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 51)
                                msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 60);
                            if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 68)
                                msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 75);
                            if (shopReportDto.ShopSubjectScoreInfoDtoList[j].LossDesc.Length >= 85)
                                msExcelUtil.SetCellHeight(worksheet_FengMian, "H", i, 90);

                            msExcelUtil.SetCellValue(worksheet_FengMian, "K", i, shopReportDto.ShopSubjectScoreInfoDtoList[j].Remark);
                        }
                    }
                }
                #endregion


            }
            #endregion
            #region 销售顾问
            Worksheet worksheet_SaleContant = workbook.Worksheets["销售顾问得分"] as Worksheet;

            if (shopReportDto.SaleContantScoreInfoList.Count > 0)
            {
                for (int i = 0; i < shopReportDto.SaleContantScoreInfoList.Count; i++)
                {
                    msExcelUtil.SetCellValue(worksheet_SaleContant, i + 7, 5, "销售顾问" + "\r\n" + shopReportDto.SaleContantScoreInfoList[i].SaleName);
                    //msExcelUtil.SetCellValue(worksheet_SaleContant, i + 7, 6, shopReportDto.SaleContantScoreInfoList[i].Score);
                }
            }

            for (int i = 17; i < 130; i++)
            {
                for (int j = 0; j < shopReportDto.SaleContantSubjectScoreDtoList.Count; j++)
                {
                    if (msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == shopReportDto.SaleContantSubjectScoreDtoList[j].SubjectCode
                        || msExcelUtil.GetCellValue(worksheet_SaleContant, "B", i).ToString() == "*" + shopReportDto.SaleContantSubjectScoreDtoList[j].SubjectCode)
                    {
                        msExcelUtil.SetCellValue(worksheet_SaleContant, "O", i, shopReportDto.SaleContantSubjectScoreDtoList[j].Remark);
                        for (int z = 7; z < 15; z++)
                        {
                            if (msExcelUtil.GetCellValue(worksheet_SaleContant, z, 5).ToString()
                            == "销售顾问" + "\r\n" + shopReportDto.SaleContantSubjectScoreDtoList[j].SaleName)
                            {
                                msExcelUtil.SetCellValue(worksheet_SaleContant, z, i, shopReportDto.SaleContantSubjectScoreDtoList[j].Score);
                                if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length > 20)
                                    msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 36);
                                if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 30)
                                    msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 48);
                                if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 40)
                                    msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 60);
                                if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 50)
                                    msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 72);
                                if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 60)
                                    msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 84);
                                if (shopReportDto.SaleContantSubjectScoreDtoList[j].Score.Length >= 70)
                                    msExcelUtil.SetCellHeight(worksheet_SaleContant, z, i, 96);

                            }
                        }
                    }
                }
            }
            #endregion
            //string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            //projectCode = projectCode.Substring(0, 4) + "Q" + projectCode.Substring(5, 1);
            workbook.Close(true, Path.Combine(tbnFilePath.Text, "2017Q3"+"Smart销售质量现场考核" + "_" + shopReportDto.ShopName + "_" + shopReportDto.AreaName + ".xlsx"), Type.Missing);
        }

        private void GenerateReport()
        {
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            _shopDtoList = new List<ShopDto>();
            //_shopDtoList = SearchAllShopByProjectCode(projectCode);
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "CheckMarkSelection") != null && gridView1.GetRowCellValue(i, "CheckMarkSelection").ToString() == "True")
                {
                    _shopDtoList.Add(gridView1.GetRow(i) as ShopDto);
                }
            }
            _shopDtoListCount = _shopDtoList.Count;
            this.Enabled = false;
            _bw = new BackgroundWorker();
            _bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            _bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            _bw.WorkerReportsProgress = true;
            _bw.RunWorkerAsync(new object[] { projectCode });
        }

        BackgroundWorker _bw;
        List<ShopDto> _shopDtoList;
        int _shopDtoListCount = 0;
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbrProgress.Value = (e.ProgressPercentage) * 100 / _shopDtoListCount;
            System.Windows.Forms.Application.DoEvents();
        }
        void WriteErrorLog(string errMessage)
        {
            string path = tbnFilePath.Text + "\\" + "Error.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, errMessage + "\r\n");
            }

        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] shopNames;
            int currentShopDtoIndex = 0;
            foreach (ShopDto shopDto in _shopDtoList)
            {
                try
                {
                    object[] arguments = e.Argument as object[];
                    ShopReportDto shopReportDto = GetShopReportDto(arguments[0] as string, shopDto.ShopCode);
                    WriteDataToExcel(shopReportDto);
                    _bw.ReportProgress(currentShopDtoIndex++);
                }
                catch (Exception ex)
                {
                    shopLeft.Add(shopDto);
                    WriteErrorLog(shopDto.ShopCode + shopDto.ShopName + ex.Message.ToString());
                    continue;
                }

            }
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            this.Enabled = true;
            List<ShopDto> gridSource = grcShop.DataSource as List<ShopDto>;

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.SetRowCellValue(i, "CheckMarkSelection", false);
                foreach (ShopDto shop in shopLeft)
                {
                    if (shop.ShopCode == gridSource[i].ShopCode)
                    {
                        gridView1.SetRowCellValue(i, "CheckMarkSelection", true);
                    }
                    //else
                    //{
                    //    gridView1.SetRowCellValue(i, "CheckMarkSelection", false);
                    //}
                }
            }
            //if (shopLeft.Count > 0)
            //{
            //    string str = string.Empty;
            //    foreach (ShopDto shop in shopLeft)
            //    {
            //        str += shop.ShopCode + ":" + shop.ShopName + ";";
            //    }
            //    CommonHandler.ShowMessage(MessageType.Information, "报告生成完毕未生成报告经销商如下:" + str);
            //}
            //else
            //{
            CommonHandler.ShowMessage(MessageType.Information, "报告生成完毕");
            //}

        }

        private void tbnFilePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                tbnFilePath.Text = fbd.SelectedPath;
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbnFilePath.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "请选择报告生成路径");
                return;
            }
            GenerateReport();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SearchAllShopByProjectCode(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //ShopNotInScore shop = new ShopNotInScore(CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString());
            //shop.ShowDialog();

        }

        private void btnModule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.Filter = "Excel(*.xlsx)|";
            ofp.FilterIndex = 2;
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                btnModule.Text = ofp.FileName;
            }
        }

        private void btnAllCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["全国环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            string allScore = msExcelUtil.GetCellValue(worksheet_FengMian, "A", 2).ToString();
            service.UploadAllScore(projectCode, allScore, "", this.UserInfoDto.UserID);
            for (int i = 2; i < 15; i++)
            {
                string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, i, 1).ToString();
                if (!string.IsNullOrEmpty(charterCode))
                {
                    string CharterScore = msExcelUtil.GetCellValue(worksheet_FengMian, i, 2).ToString();
                    service.UploadAllCharterScore(projectCode, charterCode, CharterScore, "", this.UserInfoDto.UserID);
                }
            }

            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnAreaCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["区域环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 20; i++)
            {
                string areaCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(areaCode))
                {
                    string score = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    string areaTypeCode = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    service.UploadAreaScore(projectCode, areaCode, score, "", areaTypeCode, this.UserInfoDto.UserID);
                    for (int j = 4; j < 15; j++)
                    {
                        string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(charterCode))
                        {
                            service.UploadAreaCharterScore(projectCode, areaCode, charterCode,
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString(), "", "", this.UserInfoDto.UserID);
                        }
                    }
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnShopCharter_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["经销商环节得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 150; i++)
            {
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    for (int j = 2; j < 15; j++)
                    {
                        string charterCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(charterCode))
                        {
                            service.UploadShopCharterScore(projectCode, shopCode, msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString(),
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString(), "", this.UserInfoDto.UserID);
                        }
                    }
                }
            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnShopSubject_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["经销商得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 3; i < 150; i++)
            {
                string shopCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(shopCode))
                {
                    string orderNO_All = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString() == "" ? "0" : msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    string orderNO_Area = msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString() == "" ? "0" : msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString();
                    string score = msExcelUtil.GetCellValue(worksheet_FengMian, "D", i).ToString();
                    string mustLoss = msExcelUtil.GetCellValue(worksheet_FengMian, "E", i).ToString();
                    string saleContant = msExcelUtil.GetCellValue(worksheet_FengMian, "F", i).ToString();
                    service.UploadShopScore(projectCode, shopCode, score, Convert.ToInt32(orderNO_All), 0, Convert.ToInt32(orderNO_Area), mustLoss, this.UserInfoDto.UserID, saleContant);
                    for (int j = 7; j < 120; j++)
                    {
                        string subjectCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        string score1 = msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString();
                        string fullScore = msExcelUtil.GetCellValue(worksheet_FengMian, j, 2).ToString();
                        if (!string.IsNullOrEmpty(subjectCode))
                            service.UploadShopSubjectScore(projectCode, shopCode, subjectCode, score1, "", fullScore, this.UserInfoDto.UserID);
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnAreaSubject_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["区域体系得分"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 20; i++)
            {
                string areaCode = msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                if (!string.IsNullOrEmpty(areaCode))
                {
                    string areaTypeCode = msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString();
                    for (int j = 3; j < 120; j++)
                    {
                        string subjectCode = msExcelUtil.GetCellValue(worksheet_FengMian, j, 1).ToString();
                        if (!string.IsNullOrEmpty(subjectCode))
                        {
                            service.UploadAreaSubjectScore(projectCode, areaCode, subjectCode,
                                msExcelUtil.GetCellValue(worksheet_FengMian, j, i).ToString(), this.UserInfoDto.UserID);
                        }
                    }
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }

        private void btnShopOrder_Click(object sender, EventArgs e)
        {
            Workbook workbook = msExcelUtil.OpenExcelByMSExcel(btnModule.Text);
            Worksheet worksheet_FengMian = workbook.Worksheets["经销商排名"] as Worksheet;
            string projectCode = CommonHandler.GetComboBoxSelectedValue(cboProjects).ToString();
            for (int i = 2; i < 120; i++)
            {
                string shopCode =  msExcelUtil.GetCellValue(worksheet_FengMian, "A", i).ToString();
                
                if (!string.IsNullOrEmpty(shopCode))
                {
                    int orderNO_all = Convert.ToInt32(msExcelUtil.GetCellValue(worksheet_FengMian, "B", i).ToString());
                    int orderNO_smallArea = Convert.ToInt32(msExcelUtil.GetCellValue(worksheet_FengMian, "C", i).ToString());
                    service.UploadShopOrderNO(projectCode, shopCode, orderNO_all, orderNO_smallArea);
                }

            }
            CommonHandler.ShowMessage(MessageType.Information, "上传完毕");
        }
    }
}
