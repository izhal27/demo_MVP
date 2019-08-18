using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views.Common
{
   public partial class ErrorMessageView : Form, IErrorMessageView
   {
      public ErrorMessageView()
      {
         InitializeComponent();
      }

      public void ShowErrorMessageView(string windowTitle, string errrorMessage)
      {
         Text = windowTitle;
         txtMessage.Text = errrorMessage;
         ShowDialog();
         Close();
      }

      private void btnCopy_Click(object sender, EventArgs e)
      {
         if (!string.IsNullOrWhiteSpace(txtMessage.Text))
         {
            Clipboard.SetText(txtMessage.Text);
         }
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
