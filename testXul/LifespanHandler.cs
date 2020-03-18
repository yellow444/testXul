using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testXul
{
    public class LifespanHandler : ILifeSpanHandler
    {
        //event that receive url popup
        public event Action popup_request;
        private readonly bool openPopupsAsTabs;
        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            //get url popup
            if (this.popup_request != null)
                this.popup_request();

            //stop open popup window
            newBrowser = null;
            return true;
        }
        bool ILifeSpanHandler.DoClose(IWebBrowser browserControl, IBrowser browser)
        { return false; }

        void ILifeSpanHandler.OnBeforeClose(IWebBrowser browserControl, IBrowser browser) { }

        void ILifeSpanHandler.OnAfterCreated(IWebBrowser browserControl, IBrowser browser) { }
    }

}
