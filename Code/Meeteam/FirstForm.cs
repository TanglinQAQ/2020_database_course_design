using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Model;
using DAL; 
using BLL;

namespace Meeteam
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        public string Loginid
        {
            get //这块是个啥语法？
            {
                return idbox.Text.Trim();
            }
        }
        public string Pwd
        {
            get
            {
                return pwdbox.Text.Trim();
            }
        }

        private bool checkinput()
            //检查输入有无问题,有问题false
        {
            string id = idbox.Text.Trim();
            string pwd = pwdbox.Text.Trim();

            if (id == "")
            {
                MessageBox.Show("帐号不允许为空!");
                //MessageBox.Show("帐号不允许为空!", "CTGU在线考试系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (pwd == "")
            {
                MessageBox.Show("密码不允许为空!");
                return false;
            }

            return true;
        }

        private void logbut_Click(object sender, EventArgs e)
        {
            if (!checkinput())
            {
                return;
            }


            //the login button
            String inputname = Loginid;
            /*
            Form nextform = null;  //这里暂时不考虑之后的界面

            if (nextform != null)
            {
                this.Hide();
                nextform.ShowDialog();

            }
            else
            {
                MessageBox.Show("登录失败,请检查帐号或密码是否有误!", "CTGU在线考试系统", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            */

            string username = idbox.Text.Trim();
            string pwd = pwdbox.Text.Trim();

            UserInfo userInfo1 = new UserInfo();
            userInfo1.UserName = username;
            userInfo1.PassWord = pwd;

            UserDB userdb1 = new UserDB();
            if (userdb1.login(userInfo1))
            {
                MessageBox.Show("登录成功！", "提示"); //如果登录成功
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重新输入！", "提示");
            }

        }

        private void registerbut_Click(object sender, EventArgs e)
        {
            //the register button

        }
    }
}
