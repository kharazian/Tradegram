using NUglify;
using Volo.Abp.AspNetCore.Mvc.UI.Minification.Scripts;

namespace Volo.Abp.AspNetCore.Mvc.UI.Minification.NUglify
{
    public class NUglifyJavascriptMinifier : NUglifyMinifierBase, IJavascriptMinifier
    {
        protected override UglifyResult UglifySource(string source, string fileName)
        {
            return Uglify.Js(source, fileName);
        }
    }
}