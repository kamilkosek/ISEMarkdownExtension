using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerShell.Host.ISE;
using System.Reflection;
using System.IO;
namespace ISEMarkdownExtension
{
    public class MarkdownHelper
    {
        public MarkdownHelper()
        {
            
        }
        public bool IsMarkdown
        {
            get 
            {
                try
                {
                    return (System.IO.Path.GetExtension(this.currentFile.FullPath).Equals(".md",  StringComparison.InvariantCultureIgnoreCase));
                }
                catch
                {
                    return false;
                }
            }
            
        }
        private ISEFile currentFile;

        public ISEFile CurrentFile
        {
            get { return currentFile; }
            set { currentFile = value; }
        }
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
        
                return uri.Uri.AbsoluteUri.Replace("ISEMarkdownExtension.dll","github-markdown.css");
            }
        }
        public static string css = @"
<!DOCTYPE html>
<html>
<head>
<style>
html {
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  color: #333;
  overflow: hidden;
  font-family: ""Helvetica Neue"", Helvetica, ""Segoe UI"", Arial, freesans, sans-serif;
  font-size: 16px;
  line-height: 1.6;
  word-wrap: break-word;
}

html a {
  background: transparent;
}

html a:active,
html a:hover {
  outline: 0;
}

html strong {
  font-weight: bold;
}

html h1 {
  font-size: 2em;
  margin: 0.67em 0;
}

html img {
  border: 0;
}

html hr {
  box-sizing: content-box;
  height: 0;
}

html pre {
  overflow: auto;
}

html code,
html kbd,
html pre {
  font-family: monospace, monospace;
  font-size: 1em;
}

html input {
  color: inherit;
  font: inherit;
  margin: 0;
}

html html input[disabled] {
  cursor: default;
}

html input {
  line-height: normal;
}

html input[type=""checkbox""] {
  box-sizing: border-box;
  padding: 0;
}

html table {
  border-collapse: collapse;
  border-spacing: 0;
}

html td,
html th {
  padding: 0;
}

html * {
  box-sizing: border-box;
}

html input {
  font: 13px/1.4 Helvetica, arial, nimbussansl, liberationsans, freesans, clean, sans-serif, ""Segoe UI Emoji"", ""Segoe UI Symbol"";
}

html a {
  color: #4183c4;
  text-decoration: none;
}

html a:hover,
html a:active {
  text-decoration: underline;
}

html hr {
  height: 0;
  margin: 15px 0;
  overflow: hidden;
  background: transparent;
  border: 0;
  border-bottom: 1px solid #ddd;
}

html hr:before {
  display: table;
  content: """";
}

html hr:after {
  display: table;
  clear: both;
  content: """";
}

html h1,
html h2,
html h3,
html h4,
html h5,
html h6 {
  margin-top: 15px;
  margin-bottom: 15px;
  line-height: 1.1;
}

html h1 {
  font-size: 30px;
}

html h2 {
  font-size: 21px;
}

html h3 {
  font-size: 16px;
}

html h4 {
  font-size: 14px;
}

html h5 {
  font-size: 12px;
}

html h6 {
  font-size: 11px;
}

html blockquote {
  margin: 0;
}

html ul,
html ol {
  padding: 0;
  margin-top: 0;
  margin-bottom: 0;
}

html ol ol,
html ul ol {
  list-style-type: lower-roman;
}

html ul ul ol,
html ul ol ol,
html ol ul ol,
html ol ol ol {
  list-style-type: lower-alpha;
}

html dd {
  margin-left: 0;
}

html code {
  font-family: Consolas, ""Liberation Mono"", Menlo, Courier, monospace;
  font-size: 12px;
}

html pre {
  margin-top: 0;
  margin-bottom: 0;
  font: 12px Consolas, ""Liberation Mono"", Menlo, Courier, monospace;
}

html .octicon {
  font: normal normal normal 16px/1 octicons-anchor;
  display: inline-block;
  text-decoration: none;
  text-rendering: auto;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
}

html .octicon-link:before {
  content: '\f05c';
}

html>*:first-child {
  margin-top: 0 !important;
}

html>*:last-child {
  margin-bottom: 0 !important;
}

html a:not([href]) {
  color: inherit;
  text-decoration: none;
}

html .anchor {
  position: absolute;
  top: 0;
  left: 0;
  display: block;
  padding-right: 6px;
  padding-left: 30px;
  margin-left: -30px;
}

html .anchor:focus {
  outline: none;
}

html h1,
html h2,
html h3,
html h4,
html h5,
html h6 {
  position: relative;
  margin-top: 1em;
  margin-bottom: 16px;
  font-weight: bold;
  line-height: 1.4;
}

html h1 .octicon-link,
html h2 .octicon-link,
html h3 .octicon-link,
html h4 .octicon-link,
html h5 .octicon-link,
html h6 .octicon-link {
  display: none;
  color: #000;
  vertical-align: middle;
}

html h1:hover .anchor,
html h2:hover .anchor,
html h3:hover .anchor,
html h4:hover .anchor,
html h5:hover .anchor,
html h6:hover .anchor {
  padding-left: 8px;
  margin-left: -30px;
  text-decoration: none;
}

html h1:hover .anchor .octicon-link,
html h2:hover .anchor .octicon-link,
html h3:hover .anchor .octicon-link,
html h4:hover .anchor .octicon-link,
html h5:hover .anchor .octicon-link,
html h6:hover .anchor .octicon-link {
  display: inline-block;
}

html h1 {
  padding-bottom: 0.3em;
  font-size: 2.25em;
  line-height: 1.2;
  border-bottom: 1px solid #eee;
}

html h1 .anchor {
  line-height: 1;
}

html h2 {
  padding-bottom: 0.3em;
  font-size: 1.75em;
  line-height: 1.225;
  border-bottom: 1px solid #eee;
}

html h2 .anchor {
  line-height: 1;
}

html h3 {
  font-size: 1.5em;
  line-height: 1.43;
}

html h3 .anchor {
  line-height: 1.2;
}

html h4 {
  font-size: 1.25em;
}

html h4 .anchor {
  line-height: 1.2;
}

html h5 {
  font-size: 1em;
}

html h5 .anchor {
  line-height: 1.1;
}

html h6 {
  font-size: 1em;
  color: #777;
}

html h6 .anchor {
  line-height: 1.1;
}

html p,
html blockquote,
html ul,
html ol,
html dl,
html table,
html pre {
  margin-top: 0;
  margin-bottom: 16px;
}

html hr {
  height: 4px;
  padding: 0;
  margin: 16px 0;
  background-color: #e7e7e7;
  border: 0 none;
}

html ul,
html ol {
  padding-left: 2em;
}

html ul ul,
html ul ol,
html ol ol,
html ol ul {
  margin-top: 0;
  margin-bottom: 0;
}

html li>p {
  margin-top: 16px;
}

html dl {
  padding: 0;
}

html dl dt {
  padding: 0;
  margin-top: 16px;
  font-size: 1em;
  font-style: italic;
  font-weight: bold;
}

html dl dd {
  padding: 0 16px;
  margin-bottom: 16px;
}

html blockquote {
  padding: 0 15px;
  color: #777;
  border-left: 4px solid #ddd;
}

html blockquote>:first-child {
  margin-top: 0;
}

html blockquote>:last-child {
  margin-bottom: 0;
}

html table {
  display: block;
  width: 100%;
  overflow: auto;
  word-break: normal;
  word-break: keep-all;
}

html table th {
  font-weight: bold;
}

html table th,
html table td {
  padding: 6px 13px;
  border: 1px solid #ddd;
}

html table tr {
  background-color: #fff;
  border-top: 1px solid #ccc;
}

html table tr:nth-child(2n) {
  background-color: #f8f8f8;
}

html img {
  max-width: 100%;
  box-sizing: border-box;
}

html code {
  padding: 0;
  padding-top: 0.2em;
  padding-bottom: 0.2em;
  margin: 0;
  font-size: 85%;
  background-color: rgba(0,0,0,0.04);
  border-radius: 3px;
}

html code:before,
html code:after {
  letter-spacing: -0.2em;
  content: ""\00a0"";
}

html pre>code {
  padding: 0;
  margin: 0;
  font-size: 100%;
  word-break: normal;
  white-space: pre;
  background: transparent;
  border: 0;
}

html .highlight {
  margin-bottom: 16px;
}

html .highlight pre,
html pre {
  padding: 16px;
  overflow: auto;
  font-size: 85%;
  line-height: 1.45;
  background-color: #f7f7f7;
  border-radius: 3px;
}

html .highlight pre {
  margin-bottom: 0;
  word-break: normal;
}

html pre {
  word-wrap: normal;
}

html pre code {
  display: inline;
  max-width: initial;
  padding: 0;
  margin: 0;
  overflow: initial;
  line-height: inherit;
  word-wrap: normal;
  background-color: transparent;
  border: 0;
}

html pre code:before,
html pre code:after {
  content: normal;
}

html kbd {
  display: inline-block;
  padding: 3px 5px;
  font-size: 11px;
  line-height: 10px;
  color: #555;
  vertical-align: middle;
  background-color: #fcfcfc;
  border: solid 1px #ccc;
  border-bottom-color: #bbb;
  border-radius: 3px;
  box-shadow: inset 0 -1px 0 #bbb;
}

html .pl-c {
  color: #969896;
}

html .pl-c1,
html .pl-s .pl-v {
  color: #0086b3;
}

html .pl-e,
html .pl-en {
  color: #795da3;
}

html .pl-s .pl-s1,
html .pl-smi {
  color: #333;
}

html .pl-ent {
  color: #63a35c;
}

html .pl-k {
  color: #a71d5d;
}

html .pl-pds,
html .pl-s,
html .pl-s .pl-pse .pl-s1,
html .pl-sr,
html .pl-sr .pl-cce,
html .pl-sr .pl-sra,
html .pl-sr .pl-sre {
  color: #183691;
}

html .pl-v {
  color: #ed6a43;
}

html .pl-id {
  color: #b52a1d;
}

html .pl-ii {
  background-color: #b52a1d;
  color: #f8f8f8;
}

html .pl-sr .pl-cce {
  color: #63a35c;
  font-weight: bold;
}

html .pl-ml {
  color: #693a17;
}

html .pl-mh,
html .pl-mh .pl-en,
html .pl-ms {
  color: #1d3e81;
  font-weight: bold;
}

html .pl-mq {
  color: #008080;
}

html .pl-mi {
  color: #333;
  font-style: italic;
}

html .pl-mb {
  color: #333;
  font-weight: bold;
}

html .pl-md {
  background-color: #ffecec;
  color: #bd2c00;
}

html .pl-mi1 {
  background-color: #eaffea;
  color: #55a532;
}

html .pl-mdr {
  color: #795da3;
  font-weight: bold;
}

html .pl-mo {
  color: #1d3e81;
}

html kbd {
  display: inline-block;
  padding: 3px 5px;
  font: 11px Consolas, ""Liberation Mono"", Menlo, Courier, monospace;
  line-height: 10px;
  color: #555;
  vertical-align: middle;
  background-color: #fcfcfc;
  border: solid 1px #ccc;
  border-bottom-color: #bbb;
  border-radius: 3px;
  box-shadow: inset 0 -1px 0 #bbb;
}

html .task-list-item {
  list-style-type: none;
}

html .task-list-item+.task-list-item {
  margin-top: 3px;
}

html .task-list-item input {
  margin: 0 0.35em 0.25em -1.6em;
  vertical-align: middle;
}

html :checked+.radio-label {
  z-index: 1;
  position: relative;
  border-color: #4183c4;
}
</style>
</head>
<body>

";


    }

    public class MarkdownTag
    {
        public MarkdownTag(string Name,string Tag, bool HasPrePostspace)
        {
            this.name = Name;
            this.tag = Tag;
            this.hasPrePostspace = HasPrePostspace;
            this.single = false;
        }
        public MarkdownTag(string Name,string Tag, bool HasPrePostspace, bool Single)
        {
            this.name = Name;
            this.tag = Tag;
            this.hasPrePostspace = HasPrePostspace;
            this.single = Single;
        }
               
        
        private string name;

        public string Name
        {
            get { return name; }
        }
        private string tag;

        public string Tag
        {
            get { return tag; }
        }
        private bool hasPrePostspace;

        public bool HasPrePostspace
        {
            get { return hasPrePostspace; }
        }
        private bool single;

        public bool Single
        {
            get { return single; }
        }

    }
}
