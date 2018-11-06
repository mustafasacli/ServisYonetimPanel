using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServisYonetimPanel.Core.Web.UI.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServisYonetimPanel.Core.Web.UI.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected IHttpContextAccessor _accessor;

        protected BaseApiController(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;

        }

        protected Guid ActivityId { get { return AppValues.ActivityId; } }

        protected string RequestAddress
        {
            get
            {
                string s = string.Empty;

                try
                {
                    s = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
                catch (Exception e) { }

                return s;
            }
        }

        protected string RequestMachineName
        {
            get
            {
                string s = string.Empty;

                try
                {
                    HttpContext context = HttpContext.Request.HttpContext;//.Current;
                    s = Request.Host.Host;

                    if (string.IsNullOrEmpty(s))
                    {
                        s = Dns.GetHostEntry(this.RequestAddress).HostName;
                    }
                }
                catch (Exception e)
                {
                }

                return s;
            }
        }

        protected string ResponseAddress
        {
            get
            {
                string s = string.Empty;

                try
                {
                    //s = GetIPFromDNS();
                    s = _accessor.HttpContext.Connection.LocalIpAddress.ToString();
                }
                catch (Exception e) { }

                return s;
            }
        }

        protected IEnumerable<string> GetInfoArray()
        {
            yield return $"RequestAddress : {this.RequestAddress}";
            yield return $"ResponseAddress : {this.ResponseAddress}";
            yield return $"MachineName : {Environment.MachineName}";
        }
    }
}
