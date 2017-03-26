﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ts3.pl.Utilities
{
    public static class Utilities
    {
        public static string IsActive(this HtmlHelper html, string control, string action)
        {
            var routeData = html.ViewContext.RouteData;

            var routeAction = (string)routeData.Values["action"];
            var routeControl = (string)routeData.Values["controller"];

            var returnActive = control == routeControl &&
                               action == routeAction;

            return returnActive ? "active" : "";
        }

        public static bool ShowPartialView(this HtmlHelper html, string control)
        {
            var routeData = html.ViewContext.RouteData;
           
            var routeControl = (string)routeData.Values["controller"];

            var returnActive = control == routeControl;

            return returnActive;
        }
    }
}