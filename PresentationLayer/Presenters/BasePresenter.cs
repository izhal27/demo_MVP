﻿using PresentationLayer.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Presenters
{
   public class BasePresenter : IBasePresenter
   {
      private IErrorMessageView _errorMessageView;

      public BasePresenter()
      {

      }

      public BasePresenter(IErrorMessageView errorMessageView)
      {
         _errorMessageView = errorMessageView;
      }

      public void ShowErrorMessage(string windowTitle, string errorMessage)
      {
         var errorMessageView = new ErrorMessageView();
         errorMessageView.ShowErrorMessageView(windowTitle, errorMessage);
      }
   }
}
