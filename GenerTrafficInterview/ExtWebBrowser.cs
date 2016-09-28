using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerTrafficInterview
{

    #region using region

    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    #endregion

    /// <summary>
    /// The extended web browser.
    /// </summary>
    public class ExtWebBrowser : WebBrowser
    {
        #region Fields

        /// <summary>
        /// The cookie.
        /// </summary>
        private AxHost.ConnectionPointCookie cookie;

        /// <summary>
        /// The events.
        /// </summary>
        private WebBrowserExtendedEvents events;

        #endregion

        #region Public Events

        /// <summary>
        /// The before navigate.
        /// </summary>
        public event EventHandler<WebBrowserExtendedNavigatingEventArgs> BeforeNavigate;

        /// <summary>
        /// The before new window.
        /// </summary>
        public event EventHandler<WebBrowserExtendedNavigatingEventArgs> BeforeNewWindow;

        #endregion

        #region Interfaces

        /// <summary>
        /// The WebBrowserEvents2 interface.
        /// </summary>
        [ComImport()]
        [Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {
            /// <summary>
            /// The before navigate 2.
            /// </summary>
            /// <param name="pDisp">
            /// The p disp.
            /// </param>
            /// <param name="URL">
            /// The url.
            /// </param>
            /// <param name="flags">
            /// The flags.
            /// </param>
            /// <param name="targetFrameName">
            /// The target frame name.
            /// </param>
            /// <param name="postData">
            /// The post data.
            /// </param>
            /// <param name="headers">
            /// The headers.
            /// </param>
            /// <param name="cancel">
            /// The cancel.
            /// </param>
            [DispId(250)]
            void BeforeNavigate2(
                [In] [MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] ref object URL,
                [In] ref object flags,
                [In] ref object targetFrameName,
                [In] ref object postData,
                [In] ref object headers,
                [In] [Out] ref bool cancel);

            /// <summary>
            /// The new window 3.
            /// </summary>
            /// <param name="pDisp">
            /// The p disp.
            /// </param>
            /// <param name="cancel">
            /// The cancel.
            /// </param>
            /// <param name="flags">
            /// The flags.
            /// </param>
            /// <param name="URLContext">
            /// The url context.
            /// </param>
            /// <param name="URL">
            /// The url.
            /// </param>
            [DispId(273)]
            void NewWindow3(
                [In] [MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] [Out] ref bool cancel,
                [In] ref object flags,
                [In] ref object URLContext,
                [In] ref object URL);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The create sink.
        /// </summary>
        protected override void CreateSink()
        {
            base.CreateSink();
            this.events = new WebBrowserExtendedEvents(this);
            this.cookie = new AxHost.ConnectionPointCookie(
                this.ActiveXInstance, this.events, typeof(DWebBrowserEvents2));
        }

        /// <summary>
        /// The detach sink.
        /// </summary>
        protected override void DetachSink()
        {
            if (null != this.cookie)
            {
                this.cookie.Disconnect();
                this.cookie = null;
            }

            base.DetachSink();
        }

        /// <summary>
        /// The on before navigate.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="frame">
        /// The frame.
        /// </param>
        /// <param name="cancel">
        /// The cancel.
        /// </param>
        protected void OnBeforeNavigate(string url, string frame, out bool cancel)
        {
            EventHandler<WebBrowserExtendedNavigatingEventArgs> h = this.BeforeNavigate;
            WebBrowserExtendedNavigatingEventArgs args = new WebBrowserExtendedNavigatingEventArgs(url, frame);
            if (null != h)
            {
                h(this, args);
            }
            cancel = args.Cancel;
        }

        /// <summary>
        /// The on before new window.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="cancel">
        /// The cancel.
        /// </param>
        protected void OnBeforeNewWindow(string url, out bool cancel)
        {
            EventHandler<WebBrowserExtendedNavigatingEventArgs> h = this.BeforeNewWindow;
            WebBrowserExtendedNavigatingEventArgs args = new WebBrowserExtendedNavigatingEventArgs(url, null);
            if (null != h)
            {
                h(this, args);
            }

            cancel = args.Cancel;
        }

        #endregion

        // This class will capture events from the WebBrowser
        /// <summary>
        /// The web browser extended events.
        /// </summary>
        private class WebBrowserExtendedEvents : StandardOleMarshalObject, DWebBrowserEvents2
        {
            #region Fields

            /// <summary>
            /// The _ browser.
            /// </summary>
            private ExtWebBrowser _Browser;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="WebBrowserExtendedEvents"/> class.
            /// </summary>
            /// <param name="browser">
            /// The browser.
            /// </param>
            public WebBrowserExtendedEvents(ExtWebBrowser browser)
            {
                this._Browser = browser;
            }

            #endregion

            // Implement whichever events you wish
            #region Public Methods and Operators

            /// <summary>
            /// The before navigate 2.
            /// </summary>
            /// <param name="pDisp">
            /// The p disp.
            /// </param>
            /// <param name="URL">
            /// The url.
            /// </param>
            /// <param name="flags">
            /// The flags.
            /// </param>
            /// <param name="targetFrameName">
            /// The target frame name.
            /// </param>
            /// <param name="postData">
            /// The post data.
            /// </param>
            /// <param name="headers">
            /// The headers.
            /// </param>
            /// <param name="cancel">
            /// The cancel.
            /// </param>
            public void BeforeNavigate2(
                object pDisp,
                ref object URL,
                ref object flags,
                ref object targetFrameName,
                ref object postData,
                ref object headers,
                ref bool cancel)
            {
                this._Browser.OnBeforeNavigate((string)URL, (string)targetFrameName, out cancel);
            }

            /// <summary>
            /// The new window 3.
            /// </summary>
            /// <param name="pDisp">
            /// The p disp.
            /// </param>
            /// <param name="cancel">
            /// The cancel.
            /// </param>
            /// <param name="flags">
            /// The flags.
            /// </param>
            /// <param name="URLContext">
            /// The url context.
            /// </param>
            /// <param name="URL">
            /// The url.
            /// </param>
            public void NewWindow3(
                object pDisp, ref bool cancel, ref object flags, ref object URLContext, ref object URL)
            {
                this._Browser.OnBeforeNewWindow((string)URL, out cancel);
            }

            #endregion
        }
    }

    /// <summary>
    /// The web browser extended navigating event args.
    /// </summary>
    public class WebBrowserExtendedNavigatingEventArgs : CancelEventArgs
    {
        #region Fields

        /// <summary>
        /// The _ frame.
        /// </summary>
        private string _Frame;

        /// <summary>
        /// The _ url.
        /// </summary>
        private string _Url;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WebBrowserExtendedNavigatingEventArgs"/> class.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
        /// <param name="frame">
        /// The frame.
        /// </param>
        public WebBrowserExtendedNavigatingEventArgs(string url, string frame)
            : base()
        {
            this._Url = url;
            this._Frame = frame;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the frame.
        /// </summary>
        public string Frame
        {
            get
            {
                return this._Frame;
            }
        }

        /// <summary>
        /// Gets the url.
        /// </summary>
        public string Url
        {
            get
            {
                return this._Url;
            }
        }

        #endregion
    }

}
