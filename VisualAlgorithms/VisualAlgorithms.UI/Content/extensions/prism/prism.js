/* http://prismjs.com/download.html?themes=prism&languages=markup+css+clike+aspnet+csharp+json&plugins=line-highlight+line-numbers+autolinker+show-language+highlight-keywords+previewer-base+autoloader */
var _self = "undefined" != typeof window ? window : "undefined" != typeof WorkerGlobalScope && self instanceof WorkerGlobalScope ? self : {}, Prism = function () { var e = /\blang(?:uage)?-(\w+)\b/i, t = 0, n = _self.Prism = { util: { encode: function (e) { return e instanceof a ? new a(e.type, n.util.encode(e.content), e.alias) : "Array" === n.util.type(e) ? e.map(n.util.encode) : e.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/\u00a0/g, " ") }, type: function (e) { return Object.prototype.toString.call(e).match(/\[object (\w+)\]/)[1] }, objId: function (e) { return e.__id || Object.defineProperty(e, "__id", { value: ++t }), e.__id }, clone: function (e) { var t = n.util.type(e); switch (t) { case "Object": var a = {}; for (var r in e) e.hasOwnProperty(r) && (a[r] = n.util.clone(e[r])); return a; case "Array": return e.map && e.map(function (e) { return n.util.clone(e) }) } return e } }, languages: { extend: function (e, t) { var a = n.util.clone(n.languages[e]); for (var r in t) a[r] = t[r]; return a }, insertBefore: function (e, t, a, r) { r = r || n.languages; var l = r[e]; if (2 == arguments.length) { a = arguments[1]; for (var i in a) a.hasOwnProperty(i) && (l[i] = a[i]); return l } var o = {}; for (var s in l) if (l.hasOwnProperty(s)) { if (s == t) for (var i in a) a.hasOwnProperty(i) && (o[i] = a[i]); o[s] = l[s] } return n.languages.DFS(n.languages, function (t, n) { n === r[e] && t != e && (this[t] = o) }), r[e] = o }, DFS: function (e, t, a, r) { r = r || {}; for (var l in e) e.hasOwnProperty(l) && (t.call(e, l, e[l], a || l), "Object" !== n.util.type(e[l]) || r[n.util.objId(e[l])] ? "Array" !== n.util.type(e[l]) || r[n.util.objId(e[l])] || (r[n.util.objId(e[l])] = !0, n.languages.DFS(e[l], t, l, r)) : (r[n.util.objId(e[l])] = !0, n.languages.DFS(e[l], t, null, r))) } }, plugins: {}, highlightAll: function (e, t) { var a = { callback: t, selector: 'code[class*="language-"], [class*="language-"] code, code[class*="lang-"], [class*="lang-"] code' }; n.hooks.run("before-highlightall", a); for (var r, l = a.elements || document.querySelectorAll(a.selector), i = 0; r = l[i++];) n.highlightElement(r, e === !0, a.callback) }, highlightElement: function (t, a, r) { for (var l, i, o = t; o && !e.test(o.className) ;) o = o.parentNode; o && (l = (o.className.match(e) || [, ""])[1].toLowerCase(), i = n.languages[l]), t.className = t.className.replace(e, "").replace(/\s+/g, " ") + " language-" + l, o = t.parentNode, /pre/i.test(o.nodeName) && (o.className = o.className.replace(e, "").replace(/\s+/g, " ") + " language-" + l); var s = t.textContent, u = { element: t, language: l, grammar: i, code: s }; if (n.hooks.run("before-sanity-check", u), !u.code || !u.grammar) return n.hooks.run("complete", u), void 0; if (n.hooks.run("before-highlight", u), a && _self.Worker) { var c = new Worker(n.filename); c.onmessage = function (e) { u.highlightedCode = e.data, n.hooks.run("before-insert", u), u.element.innerHTML = u.highlightedCode, r && r.call(u.element), n.hooks.run("after-highlight", u), n.hooks.run("complete", u) }, c.postMessage(JSON.stringify({ language: u.language, code: u.code, immediateClose: !0 })) } else u.highlightedCode = n.highlight(u.code, u.grammar, u.language), n.hooks.run("before-insert", u), u.element.innerHTML = u.highlightedCode, r && r.call(t), n.hooks.run("after-highlight", u), n.hooks.run("complete", u) }, highlight: function (e, t, r) { var l = n.tokenize(e, t); return a.stringify(n.util.encode(l), r) }, tokenize: function (e, t) { var a = n.Token, r = [e], l = t.rest; if (l) { for (var i in l) t[i] = l[i]; delete t.rest }e: for (var i in t) if (t.hasOwnProperty(i) && t[i]) { var o = t[i]; o = "Array" === n.util.type(o) ? o : [o]; for (var s = 0; s < o.length; ++s) { var u = o[s], c = u.inside, g = !!u.lookbehind, h = !!u.greedy, f = 0, d = u.alias; u = u.pattern || u; for (var p = 0; p < r.length; p++) { var m = r[p]; if (r.length > e.length) break e; if (!(m instanceof a)) { u.lastIndex = 0; var y = u.exec(m), v = 1; if (!y && h && p != r.length - 1) { var b = r[p + 1].matchedStr || r[p + 1], k = m + b; if (p < r.length - 2 && (k += r[p + 2].matchedStr || r[p + 2]), u.lastIndex = 0, y = u.exec(k), !y) continue; var w = y.index + (g ? y[1].length : 0); if (w >= m.length) continue; var _ = y.index + y[0].length, P = m.length + b.length; if (v = 3, P >= _) { if (r[p + 1].greedy) continue; v = 2, k = k.slice(0, P) } m = k } if (y) { g && (f = y[1].length); var w = y.index + f, y = y[0].slice(f), _ = w + y.length, S = m.slice(0, w), O = m.slice(_), j = [p, v]; S && j.push(S); var A = new a(i, c ? n.tokenize(y, c) : y, d, y, h); j.push(A), O && j.push(O), Array.prototype.splice.apply(r, j) } } } } } return r }, hooks: { all: {}, add: function (e, t) { var a = n.hooks.all; a[e] = a[e] || [], a[e].push(t) }, run: function (e, t) { var a = n.hooks.all[e]; if (a && a.length) for (var r, l = 0; r = a[l++];) r(t) } } }, a = n.Token = function (e, t, n, a, r) { this.type = e, this.content = t, this.alias = n, this.matchedStr = a || null, this.greedy = !!r }; if (a.stringify = function (e, t, r) { if ("string" == typeof e) return e; if ("Array" === n.util.type(e)) return e.map(function (n) { return a.stringify(n, t, e) }).join(""); var l = { type: e.type, content: a.stringify(e.content, t, r), tag: "span", classes: ["token", e.type], attributes: {}, language: t, parent: r }; if ("comment" == l.type && (l.attributes.spellcheck = "true"), e.alias) { var i = "Array" === n.util.type(e.alias) ? e.alias : [e.alias]; Array.prototype.push.apply(l.classes, i) } n.hooks.run("wrap", l); var o = ""; for (var s in l.attributes) o += (o ? " " : "") + s + '="' + (l.attributes[s] || "") + '"'; return "<" + l.tag + ' class="' + l.classes.join(" ") + '" ' + o + ">" + l.content + "</" + l.tag + ">" }, !_self.document) return _self.addEventListener ? (_self.addEventListener("message", function (e) { var t = JSON.parse(e.data), a = t.language, r = t.code, l = t.immediateClose; _self.postMessage(n.highlight(r, n.languages[a], a)), l && _self.close() }, !1), _self.Prism) : _self.Prism; var r = document.currentScript || [].slice.call(document.getElementsByTagName("script")).pop(); return r && (n.filename = r.src, document.addEventListener && !r.hasAttribute("data-manual") && document.addEventListener("DOMContentLoaded", n.highlightAll)), _self.Prism }(); "undefined" != typeof module && module.exports && (module.exports = Prism), "undefined" != typeof global && (global.Prism = Prism);
Prism.languages.markup = { comment: /<!--[\w\W]*?-->/, prolog: /<\?[\w\W]+?\?>/, doctype: /<!DOCTYPE[\w\W]+?>/, cdata: /<!\[CDATA\[[\w\W]*?]]>/i, tag: { pattern: /<\/?(?!\d)[^\s>\/=.$<]+(?:\s+[^\s>\/=]+(?:=(?:("|')(?:\\\1|\\?(?!\1)[\w\W])*\1|[^\s'">=]+))?)*\s*\/?>/i, inside: { tag: { pattern: /^<\/?[^\s>\/]+/i, inside: { punctuation: /^<\/?/, namespace: /^[^\s>\/:]+:/ } }, "attr-value": { pattern: /=(?:('|")[\w\W]*?(\1)|[^\s>]+)/i, inside: { punctuation: /[=>"']/ } }, punctuation: /\/?>/, "attr-name": { pattern: /[^\s>\/]+/, inside: { namespace: /^[^\s>\/:]+:/ } } } }, entity: /&#?[\da-z]{1,8};/i }, Prism.hooks.add("wrap", function (a) { "entity" === a.type && (a.attributes.title = a.content.replace(/&amp;/, "&")) }), Prism.languages.xml = Prism.languages.markup, Prism.languages.html = Prism.languages.markup, Prism.languages.mathml = Prism.languages.markup, Prism.languages.svg = Prism.languages.markup;
Prism.languages.css = { comment: /\/\*[\w\W]*?\*\//, atrule: { pattern: /@[\w-]+?.*?(;|(?=\s*\{))/i, inside: { rule: /@[\w-]+/ } }, url: /url\((?:(["'])(\\(?:\r\n|[\w\W])|(?!\1)[^\\\r\n])*\1|.*?)\)/i, selector: /[^\{\}\s][^\{\};]*?(?=\s*\{)/, string: /("|')(\\(?:\r\n|[\w\W])|(?!\1)[^\\\r\n])*\1/, property: /(\b|\B)[\w-]+(?=\s*:)/i, important: /\B!important\b/i, "function": /[-a-z0-9]+(?=\()/i, punctuation: /[(){};:]/ }, Prism.languages.css.atrule.inside.rest = Prism.util.clone(Prism.languages.css), Prism.languages.markup && (Prism.languages.insertBefore("markup", "tag", { style: { pattern: /(<style[\w\W]*?>)[\w\W]*?(?=<\/style>)/i, lookbehind: !0, inside: Prism.languages.css, alias: "language-css" } }), Prism.languages.insertBefore("inside", "attr-value", { "style-attr": { pattern: /\s*style=("|').*?\1/i, inside: { "attr-name": { pattern: /^\s*style/i, inside: Prism.languages.markup.tag.inside }, punctuation: /^\s*=\s*['"]|['"]\s*$/, "attr-value": { pattern: /.+/i, inside: Prism.languages.css } }, alias: "language-css" } }, Prism.languages.markup.tag));
Prism.languages.clike = { comment: [{ pattern: /(^|[^\\])\/\*[\w\W]*?\*\//, lookbehind: !0 }, { pattern: /(^|[^\\:])\/\/.*/, lookbehind: !0 }], string: { pattern: /(["'])(\\(?:\r\n|[\s\S])|(?!\1)[^\\\r\n])*\1/, greedy: !0 }, "class-name": { pattern: /((?:\b(?:class|interface|extends|implements|trait|instanceof|new)\s+)|(?:catch\s+\())[a-z0-9_\.\\]+/i, lookbehind: !0, inside: { punctuation: /(\.|\\)/ } }, keyword: /\b(if|else|while|do|for|return|in|instanceof|function|new|try|throw|catch|finally|null|break|continue)\b/, "boolean": /\b(true|false)\b/, "function": /[a-z0-9_]+(?=\()/i, number: /\b-?(?:0x[\da-f]+|\d*\.?\d+(?:e[+-]?\d+)?)\b/i, operator: /--?|\+\+?|!=?=?|<=?|>=?|==?=?|&&?|\|\|?|\?|\*|\/|~|\^|%/, punctuation: /[{}[\];(),.:]/ };
Prism.languages.aspnet = Prism.languages.extend("markup", { "page-directive tag": { pattern: /<%\s*@.*%>/i, inside: { "page-directive tag": /<%\s*@\s*(?:Assembly|Control|Implements|Import|Master(?:Type)?|OutputCache|Page|PreviousPageType|Reference|Register)?|%>/i, rest: Prism.languages.markup.tag.inside } }, "directive tag": { pattern: /<%.*%>/i, inside: { "directive tag": /<%\s*?[$=%#:]{0,2}|%>/i, rest: Prism.languages.csharp } } }), Prism.languages.aspnet.tag.pattern = /<(?!%)\/?[^\s>\/]+(?:\s+[^\s>\/=]+(?:=(?:("|')(?:\\\1|\\?(?!\1)[\w\W])*\1|[^\s'">=]+))?)*\s*\/?>/i, Prism.languages.insertBefore("inside", "punctuation", { "directive tag": Prism.languages.aspnet["directive tag"] }, Prism.languages.aspnet.tag.inside["attr-value"]), Prism.languages.insertBefore("aspnet", "comment", { "asp comment": /<%--[\w\W]*?--%>/ }), Prism.languages.insertBefore("aspnet", Prism.languages.javascript ? "script" : "tag", { "asp script": { pattern: /(<script(?=.*runat=['"]?server['"]?)[\w\W]*?>)[\w\W]*?(?=<\/script>)/i, lookbehind: !0, inside: Prism.languages.csharp || {} } });
Prism.languages.csharp = Prism.languages.extend("clike", { keyword: /\b(abstract|as|async|await|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|private|protected|public|readonly|ref|return|sbyte|sealed|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while|add|alias|ascending|async|await|descending|dynamic|from|get|global|group|into|join|let|orderby|partial|remove|select|set|value|var|where|yield)\b/, string: [/@("|')(\1\1|\\\1|\\?(?!\1)[\s\S])*\1/, /("|')(\\?.)*?\1/], number: /\b-?(0x[\da-f]+|\d*\.?\d+f?)\b/i }), Prism.languages.insertBefore("csharp", "keyword", { "generic-method": { pattern: /[a-z0-9_]+\s*<[^>\r\n]+?>\s*(?=\()/i, alias: "function", inside: { keyword: Prism.languages.csharp.keyword, punctuation: /[<>(),.:]/ } }, preprocessor: { pattern: /(^\s*)#.*/m, lookbehind: !0, alias: "property", inside: { directive: { pattern: /(\s*#)\b(define|elif|else|endif|endregion|error|if|line|pragma|region|undef|warning)\b/, lookbehind: !0, alias: "keyword" } } } });
Prism.languages.json = { property: /".*?"(?=\s*:)/gi, string: /"(?!:)(\\?[^"])*?"(?!:)/g, number: /\b-?(0x[\dA-Fa-f]+|\d*\.?\d+([Ee]-?\d+)?)\b/g, punctuation: /[{}[\]);,]/g, operator: /:/g, "boolean": /\b(true|false)\b/gi, "null": /\bnull\b/gi }, Prism.languages.jsonp = Prism.languages.json;
!function () { function e(e, t) { return Array.prototype.slice.call((t || document).querySelectorAll(e)) } function t(e, t) { return t = " " + t + " ", (" " + e.className + " ").replace(/[\n\t]/g, " ").indexOf(t) > -1 } function n(e, n, i) { for (var o, a = n.replace(/\s+/g, "").split(","), l = +e.getAttribute("data-line-offset") || 0, d = r() ? parseInt : parseFloat, c = d(getComputedStyle(e).lineHeight), s = 0; o = a[s++];) { o = o.split("-"); var u = +o[0], m = +o[1] || u, h = document.createElement("div"); h.textContent = Array(m - u + 2).join(" \n"), h.className = (i || "") + " line-highlight", t(e, "line-numbers") || (h.setAttribute("data-start", u), m > u && h.setAttribute("data-end", m)), h.style.top = (u - l - 1) * c + "px", t(e, "line-numbers") ? e.appendChild(h) : (e.querySelector("code") || e).appendChild(h) } } function i() { var t = location.hash.slice(1); e(".temporary.line-highlight").forEach(function (e) { e.parentNode.removeChild(e) }); var i = (t.match(/\.([\d,-]+)$/) || [, ""])[1]; if (i && !document.getElementById(t)) { var r = t.slice(0, t.lastIndexOf(".")), o = document.getElementById(r); o && (o.hasAttribute("data-line") || o.setAttribute("data-line", ""), n(o, i, "temporary "), document.querySelector(".temporary.line-highlight").scrollIntoView()) } } if ("undefined" != typeof self && self.Prism && self.document && document.querySelector) { var r = function () { var e; return function () { if ("undefined" == typeof e) { var t = document.createElement("div"); t.style.fontSize = "13px", t.style.lineHeight = "1.5", t.style.padding = 0, t.style.border = 0, t.innerHTML = "&nbsp;<br />&nbsp;", document.body.appendChild(t), e = 38 === t.offsetHeight, document.body.removeChild(t) } return e } }(), o = 0; Prism.hooks.add("complete", function (t) { var r = t.element.parentNode, a = r && r.getAttribute("data-line"); r && a && /pre/i.test(r.nodeName) && (clearTimeout(o), e(".line-highlight", r).forEach(function (e) { e.parentNode.removeChild(e) }), n(r, a), o = setTimeout(i, 1)) }), window.addEventListener && window.addEventListener("hashchange", i) } }();
!function () { "undefined" != typeof self && self.Prism && self.document && Prism.hooks.add("complete", function (e) { if (e.code) { var t = e.element.parentNode, s = /\s*\bline-numbers\b\s*/; if (t && /pre/i.test(t.nodeName) && (s.test(t.className) || s.test(e.element.className)) && !e.element.querySelector(".line-numbers-rows")) { s.test(e.element.className) && (e.element.className = e.element.className.replace(s, "")), s.test(t.className) || (t.className += " line-numbers"); var n, a = e.code.match(/\n(?!$)/g), l = a ? a.length + 1 : 1, m = new Array(l + 1); m = m.join("<span></span>"), n = document.createElement("span"), n.className = "line-numbers-rows", n.innerHTML = m, t.hasAttribute("data-start") && (t.style.counterReset = "linenumber " + (parseInt(t.getAttribute("data-start"), 10) - 1)), e.element.appendChild(n) } } }) }();
!function () { if (("undefined" == typeof self || self.Prism) && ("undefined" == typeof global || global.Prism)) { var i = /\b([a-z]{3,7}:\/\/|tel:)[\w\-+%~\/.:#=?&amp;]+/, n = /\b\S+@[\w.]+[a-z]{2}/, e = /\[([^\]]+)]\(([^)]+)\)/, t = ["comment", "url", "attr-value", "string"]; Prism.hooks.add("before-highlight", function (a) { a.grammar && !a.grammar["url-link"] && (Prism.languages.DFS(a.grammar, function (a, r, l) { t.indexOf(l) > -1 && "Array" !== Prism.util.type(r) && (r.pattern || (r = this[a] = { pattern: r }), r.inside = r.inside || {}, "comment" == l && (r.inside["md-link"] = e), "attr-value" == l ? Prism.languages.insertBefore("inside", "punctuation", { "url-link": i }, r) : r.inside["url-link"] = i, r.inside["email-link"] = n) }), a.grammar["url-link"] = i, a.grammar["email-link"] = n) }), Prism.hooks.add("wrap", function (i) { if (/-link$/.test(i.type)) { i.tag = "a"; var n = i.content; if ("email-link" == i.type && 0 != n.indexOf("mailto:")) n = "mailto:" + n; else if ("md-link" == i.type) { var t = i.content.match(e); n = t[2], i.content = t[1] } i.attributes.href = n } }) } }();
!function () { if ("undefined" != typeof self && self.Prism && self.document) { var e = { html: "HTML", xml: "XML", svg: "SVG", mathml: "MathML", css: "CSS", clike: "C-like", javascript: "JavaScript", abap: "ABAP", actionscript: "ActionScript", apacheconf: "Apache Configuration", apl: "APL", applescript: "AppleScript", asciidoc: "AsciiDoc", aspnet: "ASP.NET (C#)", autoit: "AutoIt", autohotkey: "AutoHotkey", basic: "BASIC", csharp: "C#", cpp: "C++", coffeescript: "CoffeeScript", "css-extras": "CSS Extras", fsharp: "F#", glsl: "GLSL", http: "HTTP", inform7: "Inform 7", json: "JSON", latex: "LaTeX", lolcode: "LOLCODE", matlab: "MATLAB", mel: "MEL", nasm: "NASM", nginx: "nginx", nsis: "NSIS", objectivec: "Objective-C", ocaml: "OCaml", parigp: "PARI/GP", php: "PHP", "php-extras": "PHP Extras", powershell: "PowerShell", protobuf: "Protocol Buffers", jsx: "React JSX", rest: "reST (reStructuredText)", sas: "SAS", sass: "Sass (Sass)", scss: "Sass (Scss)", sql: "SQL", typescript: "TypeScript", vhdl: "VHDL", vim: "vim", wiki: "Wiki markup", yaml: "YAML" }; Prism.hooks.add("before-highlight", function (s) { var a = s.element.parentNode; if (a && /pre/i.test(a.nodeName)) { var t, i, r = a.getAttribute("data-language") || e[s.language] || s.language.substring(0, 1).toUpperCase() + s.language.substring(1), l = a.previousSibling; l && /\s*\bprism-show-language\b\s*/.test(l.className) && l.firstChild && /\s*\bprism-show-language-label\b\s*/.test(l.firstChild.className) ? i = l.firstChild : (t = document.createElement("div"), i = document.createElement("div"), i.className = "prism-show-language-label", t.className = "prism-show-language", t.appendChild(i), a.parentNode.insertBefore(t, a)), i.innerHTML = r } }) } }();
!function () { "undefined" != typeof self && !self.Prism || "undefined" != typeof global && !global.Prism || Prism.hooks.add("wrap", function (e) { "keyword" === e.type && e.classes.push("keyword-" + e.content) }) }();
!function () { if ("undefined" != typeof self && self.Prism && self.document && Function.prototype.bind) { var t = function (t) { var e = 0, s = 0, i = t; if (i.parentNode) { do e += i.offsetLeft, s += i.offsetTop; while ((i = i.offsetParent) && i.nodeType < 9); i = t; do e -= i.scrollLeft, s -= i.scrollTop; while ((i = i.parentNode) && !/body/i.test(i.nodeName)) } return { top: s, right: innerWidth - e - t.offsetWidth, bottom: innerHeight - s - t.offsetHeight, left: e } }, e = /(?:^|\s)token(?=$|\s)/, s = /(?:^|\s)active(?=$|\s)/g, i = /(?:^|\s)flipped(?=$|\s)/g, o = function (t, e, s, i) { this._elt = null, this._type = t, this._clsRegexp = RegExp("(?:^|\\s)" + t + "(?=$|\\s)"), this._token = null, this.updater = e, this._mouseout = this.mouseout.bind(this), this.initializer = i; var n = this; s || (s = ["*"]), "Array" !== Prism.util.type(s) && (s = [s]), s.forEach(function (t) { "string" != typeof t && (t = t.lang), o.byLanguages[t] || (o.byLanguages[t] = []), o.byLanguages[t].indexOf(n) < 0 && o.byLanguages[t].push(n) }), o.byType[t] = this }; o.prototype.init = function () { this._elt || (this._elt = document.createElement("div"), this._elt.className = "prism-previewer prism-previewer-" + this._type, document.body.appendChild(this._elt), this.initializer && this.initializer()) }, o.prototype.check = function (t) { do if (e.test(t.className) && this._clsRegexp.test(t.className)) break; while (t = t.parentNode); t && t !== this._token && (this._token = t, this.show()) }, o.prototype.mouseout = function () { this._token.removeEventListener("mouseout", this._mouseout, !1), this._token = null, this.hide() }, o.prototype.show = function () { if (this._elt || this.init(), this._token) if (this.updater.call(this._elt, this._token.textContent)) { this._token.addEventListener("mouseout", this._mouseout, !1); var e = t(this._token); this._elt.className += " active", e.top - this._elt.offsetHeight > 0 ? (this._elt.className = this._elt.className.replace(i, ""), this._elt.style.top = e.top + "px", this._elt.style.bottom = "") : (this._elt.className += " flipped", this._elt.style.bottom = e.bottom + "px", this._elt.style.top = ""), this._elt.style.left = e.left + Math.min(200, this._token.offsetWidth / 2) + "px" } else this.hide() }, o.prototype.hide = function () { this._elt.className = this._elt.className.replace(s, "") }, o.byLanguages = {}, o.byType = {}, o.initEvents = function (t, e) { var s = []; o.byLanguages[e] && (s = s.concat(o.byLanguages[e])), o.byLanguages["*"] && (s = s.concat(o.byLanguages["*"])), t.addEventListener("mouseover", function (t) { var e = t.target; s.forEach(function (t) { t.check(e) }) }, !1) }, Prism.plugins.Previewer = o, Prism.hooks.add("after-highlight", function (t) { (o.byLanguages["*"] || o.byLanguages[t.language]) && o.initEvents(t.element, t.language) }) } }();
!function () { if ("undefined" != typeof self && self.Prism && self.document && document.createElement) { var e = { javascript: "clike", actionscript: "javascript", aspnet: "markup", bison: "c", c: "clike", csharp: "clike", cpp: "c", coffeescript: "javascript", crystal: "ruby", "css-extras": "css", d: "clike", dart: "clike", fsharp: "clike", glsl: "clike", go: "clike", groovy: "clike", haml: "ruby", handlebars: "markup", haxe: "clike", jade: "javascript", java: "clike", kotlin: "clike", less: "css", markdown: "markup", nginx: "clike", objectivec: "c", parser: "markup", php: "clike", "php-extras": "php", processing: "clike", protobuf: "clike", qore: "clike", jsx: ["markup", "javascript"], ruby: "clike", sass: "css", scss: "css", scala: "java", smarty: "markup", swift: "clike", textile: "markup", twig: "markup", typescript: "javascript", wiki: "markup" }, c = {}, a = Prism.plugins.autoloader = { languages_path: "components/", use_minified: !0 }, s = function (e, c, a) { var s = document.createElement("script"); s.src = e, s.async = !0, s.onload = function () { document.body.removeChild(s), c && c() }, s.onerror = function () { document.body.removeChild(s), a && a() }, document.body.appendChild(s) }, r = function (e) { return a.languages_path + "prism-" + e + (a.use_minified ? ".min" : "") + ".js" }, n = function (e, a) { var s = c[e]; s || (s = c[e] = {}); var r = a.getAttribute("data-dependencies"); !r && a.parentNode && "pre" === a.parentNode.tagName.toLowerCase() && (r = a.parentNode.getAttribute("data-dependencies")), r = r ? r.split(/\s*,\s*/g) : [], i(r, function () { t(e, function () { Prism.highlightElement(a) }) }) }, i = function (e, c, a) { "string" == typeof e && (e = [e]); var s = 0, r = e.length, n = function () { r > s ? t(e[s], function () { s++, n() }, function () { a && a(e[s]) }) : s === r && c && c(e) }; n() }, t = function (a, n, t) { var u = function () { var e = !1; a.indexOf("!") >= 0 && (e = !0, a = a.replace("!", "")); var i = c[a]; if (i || (i = c[a] = {}), n && (i.success_callbacks || (i.success_callbacks = []), i.success_callbacks.push(n)), t && (i.error_callbacks || (i.error_callbacks = []), i.error_callbacks.push(t)), !e && Prism.languages[a]) l(a); else if (!e && i.error) o(a); else if (e || !i.loading) { i.loading = !0; var u = r(a); s(u, function () { i.loading = !1, l(a) }, function () { i.loading = !1, i.error = !0, o(a) }) } }, p = e[a]; p && p.length ? i(p, u) : u() }, l = function (e) { c[e] && c[e].success_callbacks && c[e].success_callbacks.length && c[e].success_callbacks.forEach(function (c) { c(e) }) }, o = function (e) { c[e] && c[e].error_callbacks && c[e].error_callbacks.length && c[e].error_callbacks.forEach(function (c) { c(e) }) }; Prism.hooks.add("complete", function (e) { e.element && e.language && !e.grammar && n(e.language, e.element) }) } }();