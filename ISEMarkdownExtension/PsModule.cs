using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace ISEMarkdownExtension
{

    [Cmdlet(VerbsCommon.Show,"ISEMarkdownExtension")]
    public class ShowISEMarkdownExtension :PSCmdlet
    {
        protected override void BeginProcessing()
        {
            try
            {
                base.BeginProcessing();
                if (ISEControls.PowerShellTab.VerticalAddOnTools.Single(x => x.Name == "Markdown View") != null)
                    ISEControls.PowerShellTab.VerticalAddOnTools.Single(x => x.Name == "Markdown View").IsVisible = true;
            }
            catch
            {
                    ISEControls.PowerShellTab.VerticalAddOnTools.Add("Markdown View", typeof(ISEMarkdownControl), true);

            }
        }
    }
    [Cmdlet(VerbsCommon.Hide, "ISEMarkdownExtension")]
    public class HideISEMarkdownExtension : PSCmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            try
            {
                ISEControls.PowerShellTab.VerticalAddOnTools.Single(x => x.Name == "Markdown View").IsVisible = false;
            }
            catch

            { }
        }
    }
}
