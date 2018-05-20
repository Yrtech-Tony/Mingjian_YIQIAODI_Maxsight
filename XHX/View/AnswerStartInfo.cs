using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XHX.Common;

namespace XHX.View
{
    public partial class AnswerStartInfo : DevExpress.XtraEditors.XtraForm
    {
        public string ProjectCode = "";
        public string ShopCode = "";
        public string UserId = "";
        public static localhost.Service service = new localhost.Service();
        public AnswerStartInfo()
        {
            InitializeComponent();
        }
        public AnswerStartInfo(string projectCode, string shopCode, string shopName,string userID):base()
        {
            InitializeComponent();
            ProjectCode = projectCode;
            ShopCode = shopCode;
            UserId = userID;
            BindComBox.BindProject(cboProjects);
            CommonHandler.SetComboBoxSelectedValue(cboProjects, ProjectCode);
            btnShopCode.Text = ShopCode;
            txtShopName.Text = shopName;
            dateStartDate.DateTime = DateTime.Now;
        }
        private void btnAnswerStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLeaderName.Text))
            {
                CommonHandler.ShowMessage(MessageType.Information, "�鳤��������Ϊ��");
                return;
            }
            if (CommonHandler.ShowMessage(MessageType.Confirm, "ȷ��Ҫ�����𣿱���֮�󽫲����޸�") == DialogResult.Yes)
            {
                service.AnswerStartInfoSave(ProjectCode, ShopCode, txtLeaderName.Text, UserId, dateStartDate.DateTime.ToShortDateString() + " " + dateStartTime.Value.ToString("HH:mm:dd"));
                CommonHandler.ShowMessage(MessageType.Information, "�������");
            }
        }
    }
}