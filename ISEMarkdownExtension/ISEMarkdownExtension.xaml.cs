using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.PowerShell.Host.ISE;
using System.Diagnostics;
using CommonMark;
using mshtml;

namespace ISEMarkdownExtension
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ISEMarkdownControl : IAddOnToolHostObject
    {
        

        private ObjectModelRoot hostObject;
        private MarkdownHelper markdownHelper;
        public ISEMarkdownControl()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            HostObject.PowerShellTabs.SelectedPowerShellTab.PropertyChanged += CurrentPowerShellTab_PropertyChanged;
        }

        
        private void CurrentPowerShellTab_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "LastEditorWithFocus")
            {
                if(this.markdownHelper == null)
                    this.markdownHelper = new MarkdownHelper();
                else if (!this.markdownHelper.CurrentFile.Equals(HostObject.PowerShellTabs.SelectedPowerShellTab.Files.SelectedFile))
                {
                    this.markdownHelper.CurrentFile.PropertyChanged -= OnFileEdited;
                    this.markdownHelper.CurrentFile.Editor.PropertyChanged -= OnFileEdited;

                }

                this.markdownHelper.CurrentFile = HostObject.PowerShellTabs.SelectedPowerShellTab.Files.SelectedFile;

                if (this.markdownHelper.IsMarkdown)
                {
                    RefreshMarkdownView();
                    this.markdownHelper.CurrentFile.PropertyChanged += OnFileEdited;
                    this.markdownHelper.CurrentFile.Editor.PropertyChanged += OnFileEdited;
                }
                else
                {
                    wb.NavigateToString("<html>This is not a Markdown File</html>");
                }

            }
            
        }

        void OnFileEdited(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSaved")
            {
                RefreshMarkdownView();
            }
        }
        static List<MarkdownTag> MarkdownTags = new List<MarkdownTag> 
        { 
            new MarkdownTag("h1","#",true),
            new MarkdownTag("h2","##",true),
            new MarkdownTag("h3","###",true),
            new MarkdownTag("bold","__",false),
            new MarkdownTag("italic","_",false),
            new MarkdownTag("strikethrough","~~",false),
            new MarkdownTag("link","[Link](http://www.nt-guys.com)",true,true),
            new MarkdownTag("image","![alt text](http://nt-guys.com/wp-content/uploads/2014/01/cropped-banner.png)",true,true),
            new MarkdownTag("list_bullets","\n\r* Item1\n* Item2",false,true),
            new MarkdownTag("list_numbers","\n\r1. Item1\n2. Item2",false,true),

        };
        
        private void InsertMarkDownTag(string MarkdownTag, bool PreAndPostSpace, bool Single)
        {
            string s ;
            if (PreAndPostSpace)
                s = " ";
            else
                s = "";
            ISEEditor editor = this.markdownHelper.CurrentFile.Editor;

            int line = editor.CaretLine;
            int col = editor.CaretColumn;
            if (!Single)
            {
                editor.InsertText(MarkdownTag + s + "text" + s + MarkdownTag);
                editor.Select(line, col + String.Format("{0}{1}", MarkdownTag, s).Length, line, col + String.Format("{0}{1}", MarkdownTag, s).Length + 4);
            }
            else
            {
                editor.InsertText(MarkdownTag);
                
            }
        }
        private void Button_InsertTag(object sender, RoutedEventArgs e)
        {
            string clickedButton = (sender as Button).Name ;
            MarkdownTag mdt = MarkdownTags.Single(x => x.Name == clickedButton);
            InsertMarkDownTag(mdt.Tag, mdt.HasPrePostspace, mdt.Single);

        }
        private void RefreshMarkdownView()
        {
            try
            {
                var markdownHtml = MarkdownHelper.css;
                markdownHtml += CommonMark.CommonMarkConverter.Convert(this.markdownHelper.CurrentFile.Editor.Text);
                markdownHtml += "</body></html>";
                    this.Dispatcher.BeginInvoke(new Action(delegate()
                        {
                            
                            this.wb.NavigateToString(markdownHtml);
                         }

                ));
            }
            catch
            {
            }

        }
        public ObjectModelRoot HostObject
        {
            get
            {
                return this.hostObject;
            }
            set
            {
                this.hostObject = value;
                if (this.hostObject != null)
                {
                    this.Initialize();
                }
            }
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://twitter.com/kamilkosek");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet");

        }



        
    }
}
