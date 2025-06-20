﻿/*!
 * Knockout JavaScript library v3.4.0rc
 * (c) Steven Sanderson - http://knockoutjs.com/
 * License: MIT (http://www.opensource.org/licenses/mit-license.php)
 */

(function () {
    (function (n) {
        var w = this || (0, eval)("this"), u = w.document, M = w.navigator, s = w.jQuery, F = w.JSON; (function (n) { "function" === typeof define && define.amd ? define(["exports", "require"], n) : "object" === typeof exports && "object" === typeof module ? n(module.exports || exports) : n(w.ko = {}) })(function (N, O) {
            function J(a, d) { return null === a || typeof a in T ? a === d : !1 } function U(b, d) { var c; return function () { c || (c = a.a.setTimeout(function () { c = n; b() }, d)) } } function V(b, d) { var c; return function () { clearTimeout(c); c = a.a.setTimeout(b, d) } } function W(a,
            d) { d && d !== I ? "beforeChange" === d ? this.Kb(a) : this.Ha(a, d) : this.Lb(a) } function X(a, d) { null !== d && d.k && d.k() } function Y(a, d) { var c = this.Hc, e = c[v]; e.S || (this.lb && this.Ma[d] ? (c.Pb(d, a, this.Ma[d]), this.Ma[d] = null, --this.lb) : e.r[d] || c.Pb(d, a, e.s ? { ia: a } : c.uc(a))) } function K(b, d, c, e) {
                a.d[b] = { init: function (b, g, k, l, m) { var h, r; a.m(function () { var q = a.a.c(g()), p = !c !== !q, A = !r; if (A || d || p !== h) A && a.va.Aa() && (r = a.a.ua(a.f.childNodes(b), !0)), p ? (A || a.f.da(b, a.a.ua(r)), a.eb(e ? e(m, q) : m, b)) : a.f.xa(b), h = p }, null, { i: b }); return { controlsDescendantBindings: !0 } } };
                a.h.ta[b] = !1; a.f.Z[b] = !0
            } var a = "undefined" !== typeof N ? N : {}; a.b = function (b, d) { for (var c = b.split("."), e = a, f = 0; f < c.length - 1; f++) e = e[c[f]]; e[c[c.length - 1]] = d }; a.G = function (a, d, c) { a[d] = c }; a.version = "3.4.0rc"; a.b("version", a.version); a.options = { deferUpdates: !1, useOnlyNativeEvents: !1 }; a.a = function () {
                function b(a, b) { for (var c in a) a.hasOwnProperty(c) && b(c, a[c]) } function d(a, b) { if (b) for (var c in b) b.hasOwnProperty(c) && (a[c] = b[c]); return a } function c(a, b) { a.__proto__ = b; return a } function e(b, c, d, e) {
                    var h = b[c].match(r) ||
                    []; a.a.q(d.match(r), function (b) { a.a.pa(h, b, e) }); b[c] = h.join(" ")
                } var f = { __proto__: [] } instanceof Array, g = "function" === typeof Symbol, k = {}, l = {}; k[M && /Firefox\/2/i.test(M.userAgent) ? "KeyboardEvent" : "UIEvents"] = ["keyup", "keydown", "keypress"]; k.MouseEvents = "click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave".split(" "); b(k, function (a, b) { if (b.length) for (var c = 0, d = b.length; c < d; c++) l[b[c]] = a }); var m = { propertychange: !0 }, h = u && function () {
                    for (var a = 3, b = u.createElement("div"), c =
                    b.getElementsByTagName("i") ; b.innerHTML = "\x3c!--[if gt IE " + ++a + "]><i></i><![endif]--\x3e", c[0];); return 4 < a ? a : n
                }(), r = /\S+/g; return {
                    cc: ["authenticity_token", /^__RequestVerificationToken(_.*)?$/], q: function (a, b) { for (var c = 0, d = a.length; c < d; c++) b(a[c], c) }, o: function (a, b) { if ("function" == typeof Array.prototype.indexOf) return Array.prototype.indexOf.call(a, b); for (var c = 0, d = a.length; c < d; c++) if (a[c] === b) return c; return -1 }, Sb: function (a, b, c) {
                        for (var d = 0, e = a.length; d < e; d++) if (b.call(c, a[d], d)) return a[d];
                        return null
                    }, La: function (b, c) { var d = a.a.o(b, c); 0 < d ? b.splice(d, 1) : 0 === d && b.shift() }, Tb: function (b) { b = b || []; for (var c = [], d = 0, e = b.length; d < e; d++) 0 > a.a.o(c, b[d]) && c.push(b[d]); return c }, fb: function (a, b) { a = a || []; for (var c = [], d = 0, e = a.length; d < e; d++) c.push(b(a[d], d)); return c }, Ka: function (a, b) { a = a || []; for (var c = [], d = 0, e = a.length; d < e; d++) b(a[d], d) && c.push(a[d]); return c }, ra: function (a, b) { if (b instanceof Array) a.push.apply(a, b); else for (var c = 0, d = b.length; c < d; c++) a.push(b[c]); return a }, pa: function (b, c, d) {
                        var e =
                        a.a.o(a.a.zb(b), c); 0 > e ? d && b.push(c) : d || b.splice(e, 1)
                    }, ka: f, extend: d, Xa: c, Ya: f ? c : d, D: b, Ca: function (a, b) { if (!a) return a; var c = {}, d; for (d in a) a.hasOwnProperty(d) && (c[d] = b(a[d], d, a)); return c }, ob: function (b) { for (; b.firstChild;) a.removeNode(b.firstChild) }, jc: function (b) { b = a.a.V(b); for (var c = (b[0] && b[0].ownerDocument || u).createElement("div"), d = 0, e = b.length; d < e; d++) c.appendChild(a.$(b[d])); return c }, ua: function (b, c) { for (var d = 0, e = b.length, h = []; d < e; d++) { var m = b[d].cloneNode(!0); h.push(c ? a.$(m) : m) } return h },
                    da: function (b, c) { a.a.ob(b); if (c) for (var d = 0, e = c.length; d < e; d++) b.appendChild(c[d]) }, qc: function (b, c) { var d = b.nodeType ? [b] : b; if (0 < d.length) { for (var e = d[0], h = e.parentNode, m = 0, l = c.length; m < l; m++) h.insertBefore(c[m], e); m = 0; for (l = d.length; m < l; m++) a.removeNode(d[m]) } }, za: function (a, b) { if (a.length) { for (b = 8 === b.nodeType && b.parentNode || b; a.length && a[0].parentNode !== b;) a.splice(0, 1); if (1 < a.length) { var c = a[0], d = a[a.length - 1]; for (a.length = 0; c !== d;) if (a.push(c), c = c.nextSibling, !c) return; a.push(d) } } return a }, sc: function (a,
                    b) { 7 > h ? a.setAttribute("selected", b) : a.selected = b }, $a: function (a) { return null === a || a === n ? "" : a.trim ? a.trim() : a.toString().replace(/^[\s\xa0]+|[\s\xa0]+$/g, "") }, nd: function (a, b) { a = a || ""; return b.length > a.length ? !1 : a.substring(0, b.length) === b }, Mc: function (a, b) { if (a === b) return !0; if (11 === a.nodeType) return !1; if (b.contains) return b.contains(3 === a.nodeType ? a.parentNode : a); if (b.compareDocumentPosition) return 16 == (b.compareDocumentPosition(a) & 16); for (; a && a != b;) a = a.parentNode; return !!a }, nb: function (b) {
                        return a.a.Mc(b,
                        b.ownerDocument.documentElement)
                    }, Qb: function (b) { return !!a.a.Sb(b, a.a.nb) }, A: function (a) { return a && a.tagName && a.tagName.toLowerCase() }, Wb: function (b) { return a.onError ? function () { try { return b.apply(this, arguments) } catch (c) { throw a.onError && a.onError(c), c; } } : b }, setTimeout: function (b, c) { return setTimeout(a.a.Wb(b), c) }, $b: function (b) { setTimeout(function () { a.onError && a.onError(b); throw b; }, 0) }, p: function (b, c, d) {
                        var e = a.a.Wb(d); d = h && m[c]; if (a.options.useOnlyNativeEvents || d || !s) if (d || "function" != typeof b.addEventListener) if ("undefined" !=
                        typeof b.attachEvent) { var l = function (a) { e.call(b, a) }, f = "on" + c; b.attachEvent(f, l); a.a.F.oa(b, function () { b.detachEvent(f, l) }) } else throw Error("Browser doesn't support addEventListener or attachEvent"); else b.addEventListener(c, e, !1); else s(b).bind(c, e)
                    }, Da: function (b, c) {
                        if (!b || !b.nodeType) throw Error("element must be a DOM node when calling triggerEvent"); var d; "input" === a.a.A(b) && b.type && "click" == c.toLowerCase() ? (d = b.type, d = "checkbox" == d || "radio" == d) : d = !1; if (a.options.useOnlyNativeEvents || !s || d) if ("function" ==
                        typeof u.createEvent) if ("function" == typeof b.dispatchEvent) d = u.createEvent(l[c] || "HTMLEvents"), d.initEvent(c, !0, !0, w, 0, 0, 0, 0, 0, !1, !1, !1, !1, 0, b), b.dispatchEvent(d); else throw Error("The supplied element doesn't support dispatchEvent"); else if (d && b.click) b.click(); else if ("undefined" != typeof b.fireEvent) b.fireEvent("on" + c); else throw Error("Browser doesn't support triggering events"); else s(b).trigger(c)
                    }, c: function (b) { return a.H(b) ? b() : b }, zb: function (b) { return a.H(b) ? b.t() : b }, bb: function (b, c, d) {
                        var h;
                        c && ("object" === typeof b.classList ? (h = b.classList[d ? "add" : "remove"], a.a.q(c.match(r), function (a) { h.call(b.classList, a) })) : "string" === typeof b.className.baseVal ? e(b.className, "baseVal", c, d) : e(b, "className", c, d))
                    }, Za: function (b, c) { var d = a.a.c(c); if (null === d || d === n) d = ""; var e = a.f.firstChild(b); !e || 3 != e.nodeType || a.f.nextSibling(e) ? a.f.da(b, [b.ownerDocument.createTextNode(d)]) : e.data = d; a.a.Rc(b) }, rc: function (a, b) { a.name = b; if (7 >= h) try { a.mergeAttributes(u.createElement("<input name='" + a.name + "'/>"), !1) } catch (c) { } },
                    Rc: function (a) { 9 <= h && (a = 1 == a.nodeType ? a : a.parentNode, a.style && (a.style.zoom = a.style.zoom)) }, Nc: function (a) { if (h) { var b = a.style.width; a.style.width = 0; a.style.width = b } }, hd: function (b, c) { b = a.a.c(b); c = a.a.c(c); for (var d = [], e = b; e <= c; e++) d.push(e); return d }, V: function (a) { for (var b = [], c = 0, d = a.length; c < d; c++) b.push(a[c]); return b }, Yb: function (a) { return g ? Symbol(a) : a }, rd: 6 === h, sd: 7 === h, C: h, ec: function (b, c) {
                        for (var d = a.a.V(b.getElementsByTagName("input")).concat(a.a.V(b.getElementsByTagName("textarea"))), e =
                        "string" == typeof c ? function (a) { return a.name === c } : function (a) { return c.test(a.name) }, h = [], m = d.length - 1; 0 <= m; m--) e(d[m]) && h.push(d[m]); return h
                    }, ed: function (b) { return "string" == typeof b && (b = a.a.$a(b)) ? F && F.parse ? F.parse(b) : (new Function("return " + b))() : null }, Eb: function (b, c, d) {
                        if (!F || !F.stringify) throw Error("Cannot find JSON.stringify(). Some browsers (e.g., IE < 8) don't support it natively, but you can overcome this by adding a script reference to json2.js, downloadable from http://www.json.org/json2.js");
                        return F.stringify(a.a.c(b), c, d)
                    }, fd: function (c, d, e) {
                        e = e || {}; var h = e.params || {}, m = e.includeFields || this.cc, l = c; if ("object" == typeof c && "form" === a.a.A(c)) for (var l = c.action, f = m.length - 1; 0 <= f; f--) for (var g = a.a.ec(c, m[f]), k = g.length - 1; 0 <= k; k--) h[g[k].name] = g[k].value; d = a.a.c(d); var r = u.createElement("form"); r.style.display = "none"; r.action = l; r.method = "post"; for (var n in d) c = u.createElement("input"), c.type = "hidden", c.name = n, c.value = a.a.Eb(a.a.c(d[n])), r.appendChild(c); b(h, function (a, b) {
                            var c = u.createElement("input");
                            c.type = "hidden"; c.name = a; c.value = b; r.appendChild(c)
                        }); u.body.appendChild(r); e.submitter ? e.submitter(r) : r.submit(); setTimeout(function () { r.parentNode.removeChild(r) }, 0)
                    }
                }
            }(); a.b("utils", a.a); a.b("utils.arrayForEach", a.a.q); a.b("utils.arrayFirst", a.a.Sb); a.b("utils.arrayFilter", a.a.Ka); a.b("utils.arrayGetDistinctValues", a.a.Tb); a.b("utils.arrayIndexOf", a.a.o); a.b("utils.arrayMap", a.a.fb); a.b("utils.arrayPushAll", a.a.ra); a.b("utils.arrayRemoveItem", a.a.La); a.b("utils.extend", a.a.extend); a.b("utils.fieldsIncludedWithJsonPost",
            a.a.cc); a.b("utils.getFormFields", a.a.ec); a.b("utils.peekObservable", a.a.zb); a.b("utils.postJson", a.a.fd); a.b("utils.parseJson", a.a.ed); a.b("utils.registerEventHandler", a.a.p); a.b("utils.stringifyJson", a.a.Eb); a.b("utils.range", a.a.hd); a.b("utils.toggleDomNodeCssClass", a.a.bb); a.b("utils.triggerEvent", a.a.Da); a.b("utils.unwrapObservable", a.a.c); a.b("utils.objectForEach", a.a.D); a.b("utils.addOrRemoveItem", a.a.pa); a.b("utils.setTextContent", a.a.Za); a.b("unwrap", a.a.c); Function.prototype.bind || (Function.prototype.bind =
            function (a) { var d = this; if (1 === arguments.length) return function () { return d.apply(a, arguments) }; var c = Array.prototype.slice.call(arguments, 1); return function () { var e = c.slice(0); e.push.apply(e, arguments); return d.apply(a, e) } }); a.a.e = new function () {
                function a(b, g) { var k = b[c]; if (!k || "null" === k || !e[k]) { if (!g) return n; k = b[c] = "ko" + d++; e[k] = {} } return e[k] } var d = 0, c = "__ko__" + (new Date).getTime(), e = {}; return {
                    get: function (c, d) { var e = a(c, !1); return e === n ? n : e[d] }, set: function (c, d, e) {
                        if (e !== n || a(c, !1) !== n) a(c, !0)[d] =
                        e
                    }, clear: function (a) { var b = a[c]; return b ? (delete e[b], a[c] = null, !0) : !1 }, I: function () { return d++ + c }
                }
            }; a.b("utils.domData", a.a.e); a.b("utils.domData.clear", a.a.e.clear); a.a.F = new function () {
                function b(b, d) { var e = a.a.e.get(b, c); e === n && d && (e = [], a.a.e.set(b, c, e)); return e } function d(c) { var e = b(c, !1); if (e) for (var e = e.slice(0), l = 0; l < e.length; l++) e[l](c); a.a.e.clear(c); a.a.F.cleanExternalData(c); if (f[c.nodeType]) for (e = c.firstChild; c = e;) e = c.nextSibling, 8 === c.nodeType && d(c) } var c = a.a.e.I(), e = { 1: !0, 8: !0, 9: !0 },
                f = { 1: !0, 9: !0 }; return { oa: function (a, c) { if ("function" != typeof c) throw Error("Callback must be a function"); b(a, !0).push(c) }, pc: function (d, e) { var l = b(d, !1); l && (a.a.La(l, e), 0 == l.length && a.a.e.set(d, c, n)) }, $: function (b) { if (e[b.nodeType] && (d(b), f[b.nodeType])) { var c = []; a.a.ra(c, b.getElementsByTagName("*")); for (var l = 0, m = c.length; l < m; l++) d(c[l]) } return b }, removeNode: function (b) { a.$(b); b.parentNode && b.parentNode.removeChild(b) }, cleanExternalData: function (a) { s && "function" == typeof s.cleanData && s.cleanData([a]) } }
            };
            a.$ = a.a.F.$; a.removeNode = a.a.F.removeNode; a.b("cleanNode", a.$); a.b("removeNode", a.removeNode); a.b("utils.domNodeDisposal", a.a.F); a.b("utils.domNodeDisposal.addDisposeCallback", a.a.F.oa); a.b("utils.domNodeDisposal.removeDisposeCallback", a.a.F.pc); (function () {
                var b = [0, "", ""], d = [1, "<table>", "</table>"], c = [3, "<table><tbody><tr>", "</tr></tbody></table>"], e = [1, "<select multiple='multiple'>", "</select>"], f = { thead: d, tbody: d, tfoot: d, tr: [2, "<table><tbody>", "</tbody></table>"], td: c, th: c, option: e, optgroup: e },
                g = 8 >= a.a.C; a.a.ma = function (c, d) {
                    var e; if (s) if (s.parseHTML) e = s.parseHTML(c, d) || []; else { if ((e = s.clean([c], d)) && e[0]) { for (var h = e[0]; h.parentNode && 11 !== h.parentNode.nodeType;) h = h.parentNode; h.parentNode && h.parentNode.removeChild(h) } } else {
                        (e = d) || (e = u); var h = e.parentWindow || e.defaultView || w, r = a.a.$a(c).toLowerCase(), q = e.createElement("div"), p; p = (r = r.match(/^<([a-z]+)[ >]/)) && f[r[1]] || b; r = p[0]; p = "ignored<div>" + p[1] + c + p[2] + "</div>"; "function" == typeof h.innerShiv ? q.appendChild(h.innerShiv(p)) : (g && e.appendChild(q),
                        q.innerHTML = p, g && q.parentNode.removeChild(q)); for (; r--;) q = q.lastChild; e = a.a.V(q.lastChild.childNodes)
                    } return e
                }; a.a.Cb = function (b, c) { a.a.ob(b); c = a.a.c(c); if (null !== c && c !== n) if ("string" != typeof c && (c = c.toString()), s) s(b).html(c); else for (var d = a.a.ma(c, b.ownerDocument), e = 0; e < d.length; e++) b.appendChild(d[e]) }
            })(); a.b("utils.parseHtmlFragment", a.a.ma); a.b("utils.setHtml", a.a.Cb); a.N = function () {
                function b(c, d) {
                    if (c) if (8 == c.nodeType) { var f = a.N.lc(c.nodeValue); null != f && d.push({ Lc: c, cd: f }) } else if (1 == c.nodeType) for (var f =
                    0, g = c.childNodes, k = g.length; f < k; f++) b(g[f], d)
                } var d = {}; return {
                    wb: function (a) { if ("function" != typeof a) throw Error("You can only pass a function to ko.memoization.memoize()"); var b = (4294967296 * (1 + Math.random()) | 0).toString(16).substring(1) + (4294967296 * (1 + Math.random()) | 0).toString(16).substring(1); d[b] = a; return "\x3c!--[ko_memo:" + b + "]--\x3e" }, xc: function (a, b) {
                        var f = d[a]; if (f === n) throw Error("Couldn't find any memo with ID " + a + ". Perhaps it's already been unmemoized."); try {
                            return f.apply(null, b || []),
                            !0
                        } finally { delete d[a] }
                    }, yc: function (c, d) { var f = []; b(c, f); for (var g = 0, k = f.length; g < k; g++) { var l = f[g].Lc, m = [l]; d && a.a.ra(m, d); a.N.xc(f[g].cd, m); l.nodeValue = ""; l.parentNode && l.parentNode.removeChild(l) } }, lc: function (a) { return (a = a.match(/^\[ko_memo\:(.*?)\]$/)) ? a[1] : null }
                }
            }(); a.b("memoization", a.N); a.b("memoization.memoize", a.N.wb); a.b("memoization.unmemoize", a.N.xc); a.b("memoization.parseMemoText", a.N.lc); a.b("memoization.unmemoizeDomNodeAndDescendants", a.N.yc); a.Y = function () {
                function b() {
                    if (e) for (var b =
                    e, d = 0, m; g < e;) if (m = c[g++]) { if (g > b) { if (5E3 <= ++d) { g = e; a.a.$b(Error("'Too much recursion' after processing " + d + " task groups.")); break } b = e } try { m() } catch (h) { a.a.$b(h) } }
                } function d() { b(); g = e = c.length = 0 } var c = [], e = 0, f = 1, g = 0; return {
                    scheduler: w.MutationObserver ? function (a) { var b = u.createElement("div"); (new MutationObserver(a)).observe(b, { attributes: !0 }); return function () { b.classList.toggle("foo") } }(d) : u && "onreadystatechange" in u.createElement("script") ? function (a) {
                        var b = u.createElement("script"); b.onreadystatechange =
                        function () { b.onreadystatechange = null; u.documentElement.removeChild(b); b = null; a() }; u.documentElement.appendChild(b)
                    } : function (a) { setTimeout(a, 0) }, Wa: function (b) { e || a.Y.scheduler(d); c[e++] = b; return f++ }, cancel: function (a) { a -= f - e; a >= g && a < e && (c[a] = null) }, resetForTesting: function () { var a = e - g; g = e = c.length = 0; return a }, md: b
                }
            }(); a.b("tasks", a.Y); a.b("tasks.schedule", a.Y.Wa); a.b("tasks.runEarly", a.Y.md); a.ya = {
                throttle: function (b, d) {
                    b.throttleEvaluation = d; var c = null; return a.B({
                        read: b, write: function (e) {
                            clearTimeout(c);
                            c = a.a.setTimeout(function () { b(e) }, d)
                        }
                    })
                }, rateLimit: function (a, d) { var c, e, f; "number" == typeof d ? c = d : (c = d.timeout, e = d.method); a.cb = !1; f = "notifyWhenChangesStop" == e ? V : U; a.Ta(function (a) { return f(a, c) }) }, deferred: function (b, d) { if (!0 !== d) throw Error("The 'deferred' extender only accepts the value 'true', because it is not supported to turn deferral off once enabled."); b.cb || (b.cb = !0, b.Ta(function (c) { var d; return function () { a.Y.cancel(d); d = a.Y.Wa(c); b.notifySubscribers(n, "dirty") } })) }, notify: function (a, d) {
                    a.equalityComparer =
                    "always" == d ? null : J
                }
            }; var T = { undefined: 1, "boolean": 1, number: 1, string: 1 }; a.b("extenders", a.ya); a.vc = function (b, d, c) { this.ia = b; this.gb = d; this.Kc = c; this.S = !1; a.G(this, "dispose", this.k) }; a.vc.prototype.k = function () { this.S = !0; this.Kc() }; a.J = function () { a.a.Ya(this, D); D.rb(this) }; var I = "change", D = {
                rb: function (a) { a.K = {}; a.Nb = 1 }, X: function (b, d, c) { var e = this; c = c || I; var f = new a.vc(e, d ? b.bind(d) : b, function () { a.a.La(e.K[c], f); e.Ia && e.Ia(c) }); e.sa && e.sa(c); e.K[c] || (e.K[c] = []); e.K[c].push(f); return f }, notifySubscribers: function (b,
                d) { d = d || I; d === I && this.zc(); if (this.Pa(d)) try { a.l.Ub(); for (var c = this.K[d].slice(0), e = 0, f; f = c[e]; ++e) f.S || f.gb(b) } finally { a.l.end() } }, Na: function () { return this.Nb }, Uc: function (a) { return this.Na() !== a }, zc: function () { ++this.Nb }, Ta: function (b) { var d = this, c = a.H(d), e, f, g; d.Ha || (d.Ha = d.notifySubscribers, d.notifySubscribers = W); var k = b(function () { d.Mb = !1; c && g === d && (g = d()); e = !1; d.tb(f, g) && d.Ha(f = g) }); d.Lb = function (a) { d.Mb = e = !0; g = a; k() }; d.Kb = function (a) { e || (f = a, d.Ha(a, "beforeChange")) } }, Pa: function (a) {
                    return this.K[a] &&
                    this.K[a].length
                }, Sc: function (b) { if (b) return this.K[b] && this.K[b].length || 0; var d = 0; a.a.D(this.K, function (a, b) { "dirty" !== a && (d += b.length) }); return d }, tb: function (a, d) { return !this.equalityComparer || !this.equalityComparer(a, d) }, extend: function (b) { var d = this; b && a.a.D(b, function (b, e) { var f = a.ya[b]; "function" == typeof f && (d = f(d, e) || d) }); return d }
            }; a.G(D, "subscribe", D.X); a.G(D, "extend", D.extend); a.G(D, "getSubscriptionsCount", D.Sc); a.a.ka && a.a.Xa(D, Function.prototype); a.J.fn = D; a.hc = function (a) {
                return null !=
                a && "function" == typeof a.X && "function" == typeof a.notifySubscribers
            }; a.b("subscribable", a.J); a.b("isSubscribable", a.hc); a.va = a.l = function () { function b(a) { c.push(e); e = a } function d() { e = c.pop() } var c = [], e, f = 0; return { Ub: b, end: d, oc: function (b) { if (e) { if (!a.hc(b)) throw Error("Only subscribable things can act as dependencies"); e.gb.call(e.Gc, b, b.Cc || (b.Cc = ++f)) } }, w: function (a, c, e) { try { return b(), a.apply(c, e || []) } finally { d() } }, Aa: function () { if (e) return e.m.Aa() }, Sa: function () { if (e) return e.Sa } } }(); a.b("computedContext",
            a.va); a.b("computedContext.getDependenciesCount", a.va.Aa); a.b("computedContext.isInitial", a.va.Sa); a.b("ignoreDependencies", a.qd = a.l.w); var E = a.a.Yb("_latestValue"); a.O = function (b) { function d() { if (0 < arguments.length) return d.tb(d[E], arguments[0]) && (d.ga(), d[E] = arguments[0], d.fa()), this; a.l.oc(d); return d[E] } d[E] = b; a.a.ka || a.a.extend(d, a.J.fn); a.J.fn.rb(d); a.a.Ya(d, B); a.options.deferUpdates && a.ya.deferred(d, !0); return d }; var B = {
                equalityComparer: J, t: function () { return this[E] }, fa: function () { this.notifySubscribers(this[E]) },
                ga: function () { this.notifySubscribers(this[E], "beforeChange") }
            }; a.a.ka && a.a.Xa(B, a.J.fn); var H = a.O.gd = "__ko_proto__"; B[H] = a.O; a.Oa = function (b, d) { return null === b || b === n || b[H] === n ? !1 : b[H] === d ? !0 : a.Oa(b[H], d) }; a.H = function (b) { return a.Oa(b, a.O) }; a.Ba = function (b) { return "function" == typeof b && b[H] === a.O || "function" == typeof b && b[H] === a.B && b.Vc ? !0 : !1 }; a.b("observable", a.O); a.b("isObservable", a.H); a.b("isWriteableObservable", a.Ba); a.b("isWritableObservable", a.Ba); a.b("observable.fn", B); a.G(B, "peek", B.t); a.G(B,
            "valueHasMutated", B.fa); a.G(B, "valueWillMutate", B.ga); a.la = function (b) { b = b || []; if ("object" != typeof b || !("length" in b)) throw Error("The argument passed when initializing an observable array must be an array, or null, or undefined."); b = a.O(b); a.a.Ya(b, a.la.fn); return b.extend({ trackArrayChanges: !0 }) }; a.la.fn = {
                remove: function (b) {
                    for (var d = this.t(), c = [], e = "function" != typeof b || a.H(b) ? function (a) { return a === b } : b, f = 0; f < d.length; f++) { var g = d[f]; e(g) && (0 === c.length && this.ga(), c.push(g), d.splice(f, 1), f--) } c.length &&
                    this.fa(); return c
                }, removeAll: function (b) { if (b === n) { var d = this.t(), c = d.slice(0); this.ga(); d.splice(0, d.length); this.fa(); return c } return b ? this.remove(function (c) { return 0 <= a.a.o(b, c) }) : [] }, destroy: function (b) { var d = this.t(), c = "function" != typeof b || a.H(b) ? function (a) { return a === b } : b; this.ga(); for (var e = d.length - 1; 0 <= e; e--) c(d[e]) && (d[e]._destroy = !0); this.fa() }, destroyAll: function (b) { return b === n ? this.destroy(function () { return !0 }) : b ? this.destroy(function (d) { return 0 <= a.a.o(b, d) }) : [] }, indexOf: function (b) {
                    var d =
                    this(); return a.a.o(d, b)
                }, replace: function (a, d) { var c = this.indexOf(a); 0 <= c && (this.ga(), this.t()[c] = d, this.fa()) }
            }; a.a.ka && a.a.Xa(a.la.fn, a.O.fn); a.a.q("pop push reverse shift sort splice unshift".split(" "), function (b) { a.la.fn[b] = function () { var a = this.t(); this.ga(); this.Vb(a, b, arguments); var c = a[b].apply(a, arguments); this.fa(); return c === a ? this : c } }); a.a.q(["slice"], function (b) { a.la.fn[b] = function () { var a = this(); return a[b].apply(a, arguments) } }); a.b("observableArray", a.la); a.ya.trackArrayChanges = function (b,
            d) {
                function c() { if (!e) { e = !0; var c = b.notifySubscribers; b.notifySubscribers = function (a, b) { b && b !== I || ++k; return c.apply(this, arguments) }; var d = [].concat(b.t() || []); f = null; g = b.X(function (c) { c = [].concat(c || []); if (b.Pa("arrayChange")) { var e; if (!f || 1 < k) f = a.a.ib(d, c, b.hb); e = f } d = c; f = null; k = 0; e && e.length && b.notifySubscribers(e, "arrayChange") }) } } b.hb = {}; d && "object" == typeof d && a.a.extend(b.hb, d); b.hb.sparse = !0; if (!b.Vb) {
                    var e = !1, f = null, g, k = 0, l = b.sa, m = b.Ia; b.sa = function (a) { l && l.call(b, a); "arrayChange" === a && c() };
                    b.Ia = function (a) { m && m.call(b, a); "arrayChange" !== a || b.Pa("arrayChange") || (g.k(), e = !1) }; b.Vb = function (b, c, d) {
                        function m(a, b, c) { return l[l.length] = { status: a, value: b, index: c } } if (e && !k) {
                            var l = [], g = b.length, t = d.length, G = 0; switch (c) {
                                case "push": G = g; case "unshift": for (c = 0; c < t; c++) m("added", d[c], G + c); break; case "pop": G = g - 1; case "shift": g && m("deleted", b[G], G); break; case "splice": c = Math.min(Math.max(0, 0 > d[0] ? g + d[0] : d[0]), g); for (var g = 1 === t ? g : Math.min(c + (d[1] || 0), g), t = c + t - 2, G = Math.max(g, t), P = [], n = [], Q = 2; c < G; ++c,
                                ++Q) c < g && n.push(m("deleted", b[c], c)), c < t && P.push(m("added", d[Q], c)); a.a.dc(n, P); break; default: return
                            } f = l
                        }
                    }
                }
            }; var v = a.a.Yb("_state"); a.m = a.B = function (b, d, c) {
                function e() { if (0 < arguments.length) { if ("function" === typeof f) f.apply(g.pb, arguments); else throw Error("Cannot write a value to a ko.computed unless you specify a 'write' option. If you wish to read the current value, don't pass any parameters."); return this } a.l.oc(e); (g.T || g.s && e.Qa()) && e.aa(); return g.M } "object" === typeof b ? c = b : (c = c || {}, b && (c.read =
                b)); if ("function" != typeof c.read) throw Error("Pass a function that returns the value of the ko.computed"); var f = c.write, g = { M: n, T: !0, Ra: !1, Fb: !1, S: !1, Va: !1, s: !1, jd: c.read, pb: d || c.owner, i: c.disposeWhenNodeIsRemoved || c.i || null, wa: c.disposeWhen || c.wa, mb: null, r: {}, L: 0, bc: null }; e[v] = g; e.Vc = "function" === typeof f; a.a.ka || a.a.extend(e, a.J.fn); a.J.fn.rb(e); a.a.Ya(e, z); c.pure ? (g.Va = !0, g.s = !0, a.a.extend(e, $)) : c.deferEvaluation && a.a.extend(e, aa); a.options.deferUpdates && a.ya.deferred(e, !0); g.i && (g.Fb = !0, g.i.nodeType ||
                (g.i = null)); g.s || c.deferEvaluation || e.aa(); g.i && e.ba() && a.a.F.oa(g.i, g.mb = function () { e.k() }); return e
            }; var z = {
                equalityComparer: J, Aa: function () { return this[v].L }, Pb: function (a, d, c) { if (this[v].Va && d === this) throw Error("A 'pure' computed must not be called recursively"); this[v].r[a] = c; c.Ga = this[v].L++; c.na = d.Na() }, Qa: function () { var a, d, c = this[v].r; for (a in c) if (c.hasOwnProperty(a) && (d = c[a], d.ia.Uc(d.na))) return !0 }, bd: function () { this.Fa && !this[v].Ra && this.Fa() }, ba: function () { return this[v].T || 0 < this[v].L },
                ld: function () { this.Mb || this.ac() }, uc: function (a) { if (a.cb && !this[v].i) { var d = a.X(this.bd, this, "dirty"), c = a.X(this.ld, this); return { ia: a, k: function () { d.k(); c.k() } } } return a.X(this.ac, this) }, ac: function () { var b = this, d = b[v], c = b.throttleEvaluation; c && 0 <= c ? (clearTimeout(d.bc), d.bc = a.a.setTimeout(function () { b.aa() && b.notifySubscribers(d.M) }, c)) : b.Fa ? b.Fa() : b.aa() && b.notifySubscribers(d.M) }, aa: function () {
                    var b = this[v], d = b.wa; if (!b.Ra && !b.S) {
                        if (b.i && !a.a.nb(b.i) || d && d()) { if (!b.Fb) { this.k(); return } } else b.Fb =
                        !1; b.Ra = !0; try { return this.Qc() } finally { b.Ra = !1 }
                    }
                }, Qc: function () { var b = this[v], d, c = b.Va ? n : !b.L, e = { Hc: this, Ma: b.r, lb: b.L }; a.l.Ub({ Gc: e, gb: Y, m: this, Sa: c }); b.r = {}; b.L = 0; e = this.Pc(b, e); this.tb(b.M, e) && (d = !0, b.s || this.notifySubscribers(b.M, "beforeChange"), b.M = e, b.s && this.zc()); c && this.notifySubscribers(b.M, "awake"); b.L || this.k(); return d }, Pc: function (b, d) { try { var c = b.jd; return b.pb ? c.call(b.pb) : c() } finally { a.l.end(), d.lb && !b.s && a.a.D(d.Ma, X), b.T = !1 } }, t: function () {
                    var a = this[v]; (a.T && !a.L || a.s && this.Qa()) &&
                    this.aa(); return a.M
                }, Ta: function (b) { a.J.fn.Ta.call(this, b); this.Fa = function () { this.Kb(this[v].M); this[v].T = !0; this.Lb(this) } }, k: function () { var b = this[v]; !b.s && b.r && a.a.D(b.r, function (a, b) { b.k && b.k() }); b.i && b.mb && a.a.F.pc(b.i, b.mb); b.r = null; b.L = 0; b.S = !0; b.T = !1; b.s = !1; b.i = null }
            }, $ = {
                sa: function (b) {
                    var d = this, c = d[v]; if (!c.S && c.s && "change" == b) {
                        c.s = !1; if (c.T || d.Qa()) c.r = null, c.L = 0, c.T = !0, d.aa(); else {
                            var e = []; a.a.D(c.r, function (a, b) { e[b.Ga] = a }); a.a.q(e, function (a, b) {
                                var e = c.r[a], l = d.uc(e.ia); l.Ga = b; l.na =
                                e.na; c.r[a] = l
                            })
                        } c.S || d.notifySubscribers(c.M, "awake")
                    }
                }, Ia: function (b) { var d = this[v]; d.S || "change" != b || this.Pa("change") || (a.a.D(d.r, function (a, b) { b.k && (d.r[a] = { ia: b.ia, Ga: b.Ga, na: b.na }, b.k()) }), d.s = !0, this.notifySubscribers(n, "asleep")) }, Na: function () { var b = this[v]; b.s && (b.T || this.Qa()) && this.aa(); return a.J.fn.Na.call(this) }
            }, aa = { sa: function (a) { "change" != a && "beforeChange" != a || this.t() } }; a.a.ka && a.a.Xa(z, a.J.fn); var R = a.O.gd; a.m[R] = a.O; z[R] = a.m; a.Xc = function (b) { return a.Oa(b, a.m) }; a.Yc = function (b) {
                return a.Oa(b,
                a.m) && b[v] && b[v].Va
            }; a.b("computed", a.m); a.b("dependentObservable", a.m); a.b("isComputed", a.Xc); a.b("isPureComputed", a.Yc); a.b("computed.fn", z); a.G(z, "peek", z.t); a.G(z, "dispose", z.k); a.G(z, "isActive", z.ba); a.G(z, "getDependenciesCount", z.Aa); a.nc = function (b, d) { if ("function" === typeof b) return a.m(b, d, { pure: !0 }); b = a.a.extend({}, b); b.pure = !0; return a.m(b, d) }; a.b("pureComputed", a.nc); (function () {
                function b(a, f, g) {
                    g = g || new c; a = f(a); if ("object" != typeof a || null === a || a === n || a instanceof RegExp || a instanceof
                    Date || a instanceof String || a instanceof Number || a instanceof Boolean) return a; var k = a instanceof Array ? [] : {}; g.save(a, k); d(a, function (c) { var d = f(a[c]); switch (typeof d) { case "boolean": case "number": case "string": case "function": k[c] = d; break; case "object": case "undefined": var h = g.get(d); k[c] = h !== n ? h : b(d, f, g) } }); return k
                } function d(a, b) { if (a instanceof Array) { for (var c = 0; c < a.length; c++) b(c); "function" == typeof a.toJSON && b("toJSON") } else for (c in a) b(c) } function c() { this.keys = []; this.Ib = [] } a.wc = function (c) {
                    if (0 ==
                    arguments.length) throw Error("When calling ko.toJS, pass the object you want to convert."); return b(c, function (b) { for (var c = 0; a.H(b) && 10 > c; c++) b = b(); return b })
                }; a.toJSON = function (b, c, d) { b = a.wc(b); return a.a.Eb(b, c, d) }; c.prototype = { save: function (b, c) { var d = a.a.o(this.keys, b); 0 <= d ? this.Ib[d] = c : (this.keys.push(b), this.Ib.push(c)) }, get: function (b) { b = a.a.o(this.keys, b); return 0 <= b ? this.Ib[b] : n } }
            })(); a.b("toJS", a.wc); a.b("toJSON", a.toJSON); (function () {
                a.j = {
                    u: function (b) {
                        switch (a.a.A(b)) {
                            case "option": return !0 ===
                            b.__ko__hasDomDataOptionValue__ ? a.a.e.get(b, a.d.options.xb) : 7 >= a.a.C ? b.getAttributeNode("value") && b.getAttributeNode("value").specified ? b.value : b.text : b.value; case "select": return 0 <= b.selectedIndex ? a.j.u(b.options[b.selectedIndex]) : n; default: return b.value
                        }
                    }, ha: function (b, d, c) {
                        switch (a.a.A(b)) {
                            case "option": switch (typeof d) {
                                case "string": a.a.e.set(b, a.d.options.xb, n); "__ko__hasDomDataOptionValue__" in b && delete b.__ko__hasDomDataOptionValue__; b.value = d; break; default: a.a.e.set(b, a.d.options.xb, d),
                                b.__ko__hasDomDataOptionValue__ = !0, b.value = "number" === typeof d ? d : ""
                            } break; case "select": if ("" === d || null === d) d = n; for (var e = -1, f = 0, g = b.options.length, k; f < g; ++f) if (k = a.j.u(b.options[f]), k == d || "" == k && d === n) { e = f; break } if (c || 0 <= e || d === n && 1 < b.size) b.selectedIndex = e; break; default: if (null === d || d === n) d = ""; b.value = d
                        }
                    }
                }
            })(); a.b("selectExtensions", a.j); a.b("selectExtensions.readValue", a.j.u); a.b("selectExtensions.writeValue", a.j.ha); a.h = function () {
                function b(b) {
                    b = a.a.$a(b); 123 === b.charCodeAt(0) && (b = b.slice(1,
                    -1)); var c = [], d = b.match(e), r, k = [], p = 0; if (d) {
                        d.push(","); for (var A = 0, y; y = d[A]; ++A) {
                            var t = y.charCodeAt(0); if (44 === t) { if (0 >= p) { c.push(r && k.length ? { key: r, value: k.join("") } : { unknown: r || k.join("") }); r = p = 0; k = []; continue } } else if (58 === t) { if (!p && !r && 1 === k.length) { r = k.pop(); continue } } else 47 === t && A && 1 < y.length ? (t = d[A - 1].match(f)) && !g[t[0]] && (b = b.substr(b.indexOf(y) + 1), d = b.match(e), d.push(","), A = -1, y = "/") : 40 === t || 123 === t || 91 === t ? ++p : 41 === t || 125 === t || 93 === t ? --p : r || k.length || 34 !== t && 39 !== t || (y = y.slice(1, -1));
                            k.push(y)
                        }
                    } return c
                } var d = ["true", "false", "null", "undefined"], c = /^(?:[$_a-z][$\w]*|(.+)(\.\s*[$_a-z][$\w]*|\[.+\]))$/i, e = RegExp("\"(?:[^\"\\\\]|\\\\.)*\"|'(?:[^'\\\\]|\\\\.)*'|/(?:[^/\\\\]|\\\\.)*/w*|[^\\s:,/][^,\"'{}()/:[\\]]*[^\\s,\"'{}()/:[\\]]|[^\\s]", "g"), f = /[\])"'A-Za-z0-9_$]+$/, g = { "in": 1, "return": 1, "typeof": 1 }, k = {}; return {
                    ta: [], ea: k, yb: b, Ua: function (e, m) {
                        function h(b, e) {
                            var m; if (!A) {
                                var l = a.getBindingHandler(b); if (l && l.preprocess && !(e = l.preprocess(e, b, h))) return; if (l = k[b]) m = e, 0 <= a.a.o(d, m) ?
                                m = !1 : (l = m.match(c), m = null === l ? !1 : l[1] ? "Object(" + l[1] + ")" + l[2] : m), l = m; l && g.push("'" + b + "':function(_z){" + m + "=_z}")
                            } p && (e = "function(){return " + e + " }"); f.push("'" + b + "':" + e)
                        } m = m || {}; var f = [], g = [], p = m.valueAccessors, A = m.bindingParams, y = "string" === typeof e ? b(e) : e; a.a.q(y, function (a) { h(a.key || a.unknown, a.value) }); g.length && h("_ko_property_writers", "{" + g.join(",") + " }"); return f.join(",")
                    }, ad: function (a, b) { for (var c = 0; c < a.length; c++) if (a[c].key == b) return !0; return !1 }, Ea: function (b, c, d, e, f) {
                        if (b && a.H(b)) !a.Ba(b) ||
                        f && b.t() === e || b(e); else if ((b = c.get("_ko_property_writers")) && b[d]) b[d](e)
                    }
                }
            }(); a.b("expressionRewriting", a.h); a.b("expressionRewriting.bindingRewriteValidators", a.h.ta); a.b("expressionRewriting.parseObjectLiteral", a.h.yb); a.b("expressionRewriting.preProcessBindings", a.h.Ua); a.b("expressionRewriting._twoWayBindings", a.h.ea); a.b("jsonExpressionRewriting", a.h); a.b("jsonExpressionRewriting.insertPropertyAccessorsIntoJson", a.h.Ua); (function () {
                function b(a) { return 8 == a.nodeType && g.test(f ? a.text : a.nodeValue) }
                function d(a) { return 8 == a.nodeType && k.test(f ? a.text : a.nodeValue) } function c(a, c) { for (var e = a, f = 1, l = []; e = e.nextSibling;) { if (d(e) && (f--, 0 === f)) return l; l.push(e); b(e) && f++ } if (!c) throw Error("Cannot find closing comment tag to match: " + a.nodeValue); return null } function e(a, b) { var d = c(a, b); return d ? 0 < d.length ? d[d.length - 1].nextSibling : a.nextSibling : null } var f = u && "\x3c!--test--\x3e" === u.createComment("test").text, g = f ? /^\x3c!--\s*ko(?:\s+([\s\S]+))?\s*--\x3e$/ : /^\s*ko(?:\s+([\s\S]+))?\s*$/, k = f ? /^\x3c!--\s*\/ko\s*--\x3e$/ :
                /^\s*\/ko\s*$/, l = { ul: !0, ol: !0 }; a.f = {
                    Z: {}, childNodes: function (a) { return b(a) ? c(a) : a.childNodes }, xa: function (c) { if (b(c)) { c = a.f.childNodes(c); for (var d = 0, e = c.length; d < e; d++) a.removeNode(c[d]) } else a.a.ob(c) }, da: function (c, d) { if (b(c)) { a.f.xa(c); for (var e = c.nextSibling, f = 0, l = d.length; f < l; f++) e.parentNode.insertBefore(d[f], e) } else a.a.da(c, d) }, mc: function (a, c) { b(a) ? a.parentNode.insertBefore(c, a.nextSibling) : a.firstChild ? a.insertBefore(c, a.firstChild) : a.appendChild(c) }, gc: function (c, d, e) {
                        e ? b(c) ? c.parentNode.insertBefore(d,
                        e.nextSibling) : e.nextSibling ? c.insertBefore(d, e.nextSibling) : c.appendChild(d) : a.f.mc(c, d)
                    }, firstChild: function (a) { return b(a) ? !a.nextSibling || d(a.nextSibling) ? null : a.nextSibling : a.firstChild }, nextSibling: function (a) { b(a) && (a = e(a)); return a.nextSibling && d(a.nextSibling) ? null : a.nextSibling }, Tc: b, pd: function (a) { return (a = (f ? a.text : a.nodeValue).match(g)) ? a[1] : null }, kc: function (c) {
                        if (l[a.a.A(c)]) {
                            var h = c.firstChild; if (h) {
                                do if (1 === h.nodeType) {
                                    var f; f = h.firstChild; var g = null; if (f) {
                                        do if (g) g.push(f); else if (b(f)) {
                                            var k =
                                            e(f, !0); k ? f = k : g = [f]
                                        } else d(f) && (g = [f]); while (f = f.nextSibling)
                                    } if (f = g) for (g = h.nextSibling, k = 0; k < f.length; k++) g ? c.insertBefore(f[k], g) : c.appendChild(f[k])
                                } while (h = h.nextSibling)
                            }
                        }
                    }
                }
            })(); a.b("virtualElements", a.f); a.b("virtualElements.allowedBindings", a.f.Z); a.b("virtualElements.emptyNode", a.f.xa); a.b("virtualElements.insertAfter", a.f.gc); a.b("virtualElements.prepend", a.f.mc); a.b("virtualElements.setDomNodeChildren", a.f.da); (function () {
                a.R = function () { this.Fc = {} }; a.a.extend(a.R.prototype, {
                    nodeHasBindings: function (b) {
                        switch (b.nodeType) {
                            case 1: return null !=
                            b.getAttribute("data-bind") || a.g.getComponentNameForNode(b); case 8: return a.f.Tc(b); default: return !1
                        }
                    }, getBindings: function (b, d) { var c = this.getBindingsString(b, d), c = c ? this.parseBindingsString(c, d, b) : null; return a.g.Ob(c, b, d, !1) }, getBindingAccessors: function (b, d) { var c = this.getBindingsString(b, d), c = c ? this.parseBindingsString(c, d, b, { valueAccessors: !0 }) : null; return a.g.Ob(c, b, d, !0) }, getBindingsString: function (b) { switch (b.nodeType) { case 1: return b.getAttribute("data-bind"); case 8: return a.f.pd(b); default: return null } },
                    parseBindingsString: function (b, d, c, e) { try { var f = this.Fc, g = b + (e && e.valueAccessors || ""), k; if (!(k = f[g])) { var l, m = "with($context){with($data||{}){return{" + a.h.Ua(b, e) + "}}}"; l = new Function("$context", "$element", m); k = f[g] = l } return k(d, c) } catch (h) { throw h.message = "Unable to parse bindings.\nBindings value: " + b + "\nMessage: " + h.message, h; } }
                }); a.R.instance = new a.R
            })(); a.b("bindingProvider", a.R); (function () {
                function b(a) { return function () { return a } } function d(a) { return a() } function c(b) {
                    return a.a.Ca(a.l.w(b),
                    function (a, c) { return function () { return b()[c] } })
                } function e(d, e, h) { return "function" === typeof d ? c(d.bind(null, e, h)) : a.a.Ca(d, b) } function f(a, b) { return c(this.getBindings.bind(this, a, b)) } function g(b, c, d) { var e, h = a.f.firstChild(c), f = a.R.instance, m = f.preprocessNode; if (m) { for (; e = h;) h = a.f.nextSibling(e), m.call(f, e); h = a.f.firstChild(c) } for (; e = h;) h = a.f.nextSibling(e), k(b, e, d) } function k(b, c, d) {
                    var e = !0, h = 1 === c.nodeType; h && a.f.kc(c); if (h && d || a.R.instance.nodeHasBindings(c)) e = m(c, null, b, d).shouldBindDescendants;
                    e && !r[a.a.A(c)] && g(b, c, !h)
                } function l(b) { var c = [], d = {}, e = []; a.a.D(b, function Z(h) { if (!d[h]) { var f = a.getBindingHandler(h); f && (f.after && (e.push(h), a.a.q(f.after, function (c) { if (b[c]) { if (-1 !== a.a.o(e, c)) throw Error("Cannot combine the following bindings, because they have a cyclic dependency: " + e.join(", ")); Z(c) } }), e.length--), c.push({ key: h, fc: f })); d[h] = !0 } }); return c } function m(b, c, e, h) {
                    var m = a.a.e.get(b, q); if (!c) {
                        if (m) throw Error("You cannot apply bindings multiple times to the same element."); a.a.e.set(b,
                        q, !0)
                    } !m && h && a.tc(b, e); var g; if (c && "function" !== typeof c) g = c; else { var k = a.R.instance, r = k.getBindingAccessors || f, p = a.B(function () { (g = c ? c(e, b) : r.call(k, b, e)) && e.Q && e.Q(); return g }, null, { i: b }); g && p.ba() || (p = null) } var u; if (g) {
                        var s = p ? function (a) { return function () { return d(p()[a]) } } : function (a) { return g[a] }, v = function () { return a.a.Ca(p ? p() : g, d) }; v.get = function (a) { return g[a] && d(s(a)) }; v.has = function (a) { return a in g }; h = l(g); a.a.q(h, function (c) {
                            var d = c.fc.init, h = c.fc.update, f = c.key; if (8 === b.nodeType && !a.f.Z[f]) throw Error("The binding '" +
                            f + "' cannot be used with virtual elements"); try { "function" == typeof d && a.l.w(function () { var a = d(b, s(f), v, e.$data, e); if (a && a.controlsDescendantBindings) { if (u !== n) throw Error("Multiple bindings (" + u + " and " + f + ") are trying to control descendant bindings of the same element. You cannot use these bindings together on the same element."); u = f } }), "function" == typeof h && a.B(function () { h(b, s(f), v, e.$data, e) }, null, { i: b }) } catch (m) {
                                throw m.message = 'Unable to process binding "' + f + ": " + g[f] + '"\nMessage: ' + m.message,
                                m;
                            }
                        })
                    } return { shouldBindDescendants: u === n }
                } function h(b) { return b && b instanceof a.U ? b : new a.U(b) } a.d = {}; var r = { script: !0, textarea: !0, template: !0 }; a.getBindingHandler = function (b) { return a.d[b] }; a.U = function (b, c, d, e) {
                    var h = this, f = "function" == typeof b && !a.H(b), m, g = a.B(function () { var m = f ? b() : b, l = a.a.c(m); c ? (c.Q && c.Q(), a.a.extend(h, c), g && (h.Q = g)) : (h.$parents = [], h.$root = l, h.ko = a); h.$rawData = m; h.$data = l; d && (h[d] = l); e && e(h, c, l); return h.$data }, null, { wa: function () { return m && !a.a.Qb(m) }, i: !0 }); g.ba() && (h.Q =
                    g, g.equalityComparer = null, m = [], g.Ac = function (b) { m.push(b); a.a.F.oa(b, function (b) { a.a.La(m, b); m.length || (g.k(), h.Q = g = n) }) })
                }; a.U.prototype.createChildContext = function (b, c, d) { return new a.U(b, this, c, function (a, b) { a.$parentContext = b; a.$parent = b.$data; a.$parents = (b.$parents || []).slice(0); a.$parents.unshift(a.$parent); d && d(a) }) }; a.U.prototype.extend = function (b) { return new a.U(this.Q || this.$data, this, null, function (c, d) { c.$rawData = d.$rawData; a.a.extend(c, "function" == typeof b ? b() : b) }) }; var q = a.a.e.I(), p =
                a.a.e.I(); a.tc = function (b, c) { if (2 == arguments.length) a.a.e.set(b, p, c), c.Q && c.Q.Ac(b); else return a.a.e.get(b, p) }; a.Ja = function (b, c, d) { 1 === b.nodeType && a.f.kc(b); return m(b, c, h(d), !0) }; a.Dc = function (b, c, d) { d = h(d); return a.Ja(b, e(c, d, b), d) }; a.eb = function (a, b) { 1 !== b.nodeType && 8 !== b.nodeType || g(h(a), b, !0) }; a.Rb = function (a, b) {
                    !s && w.jQuery && (s = w.jQuery); if (b && 1 !== b.nodeType && 8 !== b.nodeType) throw Error("ko.applyBindings: first parameter should be your view model; second parameter should be a DOM node"); b =
                    b || w.document.body; k(h(a), b, !0)
                }; a.kb = function (b) { switch (b.nodeType) { case 1: case 8: var c = a.tc(b); if (c) return c; if (b.parentNode) return a.kb(b.parentNode) } return n }; a.Jc = function (b) { return (b = a.kb(b)) ? b.$data : n }; a.b("bindingHandlers", a.d); a.b("applyBindings", a.Rb); a.b("applyBindingsToDescendants", a.eb); a.b("applyBindingAccessorsToNode", a.Ja); a.b("applyBindingsToNode", a.Dc); a.b("contextFor", a.kb); a.b("dataFor", a.Jc)
            })(); (function (b) {
                function d(d, e) {
                    var m = f.hasOwnProperty(d) ? f[d] : b, h; m ? m.X(e) : (m = f[d] =
                    new a.J, m.X(e), c(d, function (b, c) { var e = !(!c || !c.synchronous); g[d] = { definition: b, Zc: e }; delete f[d]; h || e ? m.notifySubscribers(b) : a.Y.Wa(function () { m.notifySubscribers(b) }) }), h = !0)
                } function c(a, b) { e("getConfig", [a], function (c) { c ? e("loadComponent", [a, c], function (a) { b(a, c) }) : b(null, null) }) } function e(c, d, f, h) {
                    h || (h = a.g.loaders.slice(0)); var g = h.shift(); if (g) {
                        var q = g[c]; if (q) {
                            var p = !1; if (q.apply(g, d.concat(function (a) { p ? f(null) : null !== a ? f(a) : e(c, d, f, h) })) !== b && (p = !0, !g.suppressLoaderExceptions)) throw Error("Component loaders must supply values by invoking the callback, not by returning values synchronously.");
                        } else e(c, d, f, h)
                    } else f(null)
                } var f = {}, g = {}; a.g = { get: function (c, e) { var f = g.hasOwnProperty(c) ? g[c] : b; f ? f.Zc ? a.l.w(function () { e(f.definition) }) : a.Y.Wa(function () { e(f.definition) }) : d(c, e) }, Xb: function (a) { delete g[a] }, Jb: e }; a.g.loaders = []; a.b("components", a.g); a.b("components.get", a.g.get); a.b("components.clearCachedDefinition", a.g.Xb)
            })(); (function () {
                function b(b, c, d, e) {
                    function g() { 0 === --y && e(k) } var k = {}, y = 2, t = d.template; d = d.viewModel; t ? f(c, t, function (c) {
                        a.g.Jb("loadTemplate", [b, c], function (a) {
                            k.template =
                            a; g()
                        })
                    }) : g(); d ? f(c, d, function (c) { a.g.Jb("loadViewModel", [b, c], function (a) { k[l] = a; g() }) }) : g()
                } function d(a, b, c) { if ("function" === typeof b) c(function (a) { return new b(a) }); else if ("function" === typeof b[l]) c(b[l]); else if ("instance" in b) { var e = b.instance; c(function () { return e }) } else "viewModel" in b ? d(a, b.viewModel, c) : a("Unknown viewModel value: " + b) } function c(b) { switch (a.a.A(b)) { case "script": return a.a.ma(b.text); case "textarea": return a.a.ma(b.value); case "template": if (e(b.content)) return a.a.ua(b.content.childNodes) } return a.a.ua(b.childNodes) }
                function e(a) { return w.DocumentFragment ? a instanceof DocumentFragment : a && 11 === a.nodeType } function f(a, b, c) { "string" === typeof b.require ? O || w.require ? (O || w.require)([b.require], c) : a("Uses require, but no AMD loader is present") : c(b) } function g(a) { return function (b) { throw Error("Component '" + a + "': " + b); } } var k = {}; a.g.register = function (b, c) { if (!c) throw Error("Invalid configuration for " + b); if (a.g.ub(b)) throw Error("Component " + b + " is already registered"); k[b] = c }; a.g.ub = function (a) { return k.hasOwnProperty(a) };
                a.g.od = function (b) { delete k[b]; a.g.Xb(b) }; a.g.Zb = {
                    getConfig: function (a, b) { b(k.hasOwnProperty(a) ? k[a] : null) }, loadComponent: function (a, c, d) { var e = g(a); f(e, c, function (c) { b(a, e, c, d) }) }, loadTemplate: function (b, d, f) {
                        b = g(b); if ("string" === typeof d) f(a.a.ma(d)); else if (d instanceof Array) f(d); else if (e(d)) f(a.a.V(d.childNodes)); else if (d.element) if (d = d.element, w.HTMLElement ? d instanceof HTMLElement : d && d.tagName && 1 === d.nodeType) f(c(d)); else if ("string" === typeof d) {
                            var l = u.getElementById(d); l ? f(c(l)) : b("Cannot find element with ID " +
                            d)
                        } else b("Unknown element type: " + d); else b("Unknown template value: " + d)
                    }, loadViewModel: function (a, b, c) { d(g(a), b, c) }
                }; var l = "createViewModel"; a.b("components.register", a.g.register); a.b("components.isRegistered", a.g.ub); a.b("components.unregister", a.g.od); a.b("components.defaultLoader", a.g.Zb); a.g.loaders.push(a.g.Zb); a.g.Bc = k
            })(); (function () {
                function b(b, e) {
                    var f = b.getAttribute("params"); if (f) {
                        var f = d.parseBindingsString(f, e, b, { valueAccessors: !0, bindingParams: !0 }), f = a.a.Ca(f, function (d) {
                            return a.m(d,
                            null, { i: b })
                        }), g = a.a.Ca(f, function (d) { var e = d.t(); return d.ba() ? a.m({ read: function () { return a.a.c(d()) }, write: a.Ba(e) && function (a) { d()(a) }, i: b }) : e }); g.hasOwnProperty("$raw") || (g.$raw = f); return g
                    } return { $raw: {} }
                } a.g.getComponentNameForNode = function (b) { var d = a.a.A(b); if (a.g.ub(d) && (-1 != d.indexOf("-") || "[object HTMLUnknownElement]" == "" + b || 8 >= a.a.C && b.tagName === d)) return d }; a.g.Ob = function (c, d, f, g) {
                    if (1 === d.nodeType) {
                        var k = a.g.getComponentNameForNode(d); if (k) {
                            c = c || {}; if (c.component) throw Error('Cannot use the "component" binding on a custom element matching a component');
                            var l = { name: k, params: b(d, f) }; c.component = g ? function () { return l } : l
                        }
                    } return c
                }; var d = new a.R; 9 > a.a.C && (a.g.register = function (a) { return function (b) { u.createElement(b); return a.apply(this, arguments) } }(a.g.register), u.createDocumentFragment = function (b) { return function () { var d = b(), f = a.g.Bc, g; for (g in f) f.hasOwnProperty(g) && d.createElement(g); return d } }(u.createDocumentFragment))
            })(); (function (b) {
                function d(b, c, d) { c = c.template; if (!c) throw Error("Component '" + b + "' has no template"); b = a.a.ua(c); a.f.da(d, b) }
                function c(a, b, c, d) { var e = a.createViewModel; return e ? e.call(a, d, { element: b, templateNodes: c }) : d } var e = 0; a.d.component = {
                    init: function (f, g, k, l, m) {
                        function h() { var a = r && r.dispose; "function" === typeof a && a.call(r); q = r = null } var r, q, p = a.a.V(a.f.childNodes(f)); a.a.F.oa(f, h); a.m(function () {
                            var l = a.a.c(g()), k, t; "string" === typeof l ? k = l : (k = a.a.c(l.name), t = a.a.c(l.params)); if (!k) throw Error("No component name specified"); var n = q = ++e; a.g.get(k, function (e) {
                                if (q === n) {
                                    h(); if (!e) throw Error("Unknown component '" + k +
                                    "'"); d(k, e, f); var g = c(e, f, p, t); e = m.createChildContext(g, b, function (a) { a.$component = g; a.$componentTemplateNodes = p }); r = g; a.eb(e, f)
                                }
                            })
                        }, null, { i: f }); return { controlsDescendantBindings: !0 }
                    }
                }; a.f.Z.component = !0
            })(); var S = { "class": "className", "for": "htmlFor" }; a.d.attr = {
                update: function (b, d) {
                    var c = a.a.c(d()) || {}; a.a.D(c, function (c, d) {
                        d = a.a.c(d); var g = !1 === d || null === d || d === n; g && b.removeAttribute(c); 8 >= a.a.C && c in S ? (c = S[c], g ? b.removeAttribute(c) : b[c] = d) : g || b.setAttribute(c, d.toString()); "name" === c && a.a.rc(b,
                        g ? "" : d.toString())
                    })
                }
            }; (function () {
                a.d.checked = {
                    after: ["value", "attr"], init: function (b, d, c) {
                        function e() { var e = b.checked, f = p ? g() : e; if (!a.va.Sa() && (!l || e)) { var m = a.l.w(d); if (h) { var k = r ? m.t() : m; q !== f ? (e && (a.a.pa(k, f, !0), a.a.pa(k, q, !1)), q = f) : a.a.pa(k, f, e); r && a.Ba(m) && m(k) } else a.h.Ea(m, c, "checked", f, !0) } } function f() { var c = a.a.c(d()); b.checked = h ? 0 <= a.a.o(c, g()) : k ? c : g() === c } var g = a.nc(function () { return c.has("checkedValue") ? a.a.c(c.get("checkedValue")) : c.has("value") ? a.a.c(c.get("value")) : b.value }), k =
                        "checkbox" == b.type, l = "radio" == b.type; if (k || l) { var m = d(), h = k && a.a.c(m) instanceof Array, r = !(h && m.push && m.splice), q = h ? g() : n, p = l || h; l && !b.name && a.d.uniqueName.init(b, function () { return !0 }); a.m(e, null, { i: b }); a.a.p(b, "click", e); a.m(f, null, { i: b }); m = n }
                    }
                }; a.h.ea.checked = !0; a.d.checkedValue = { update: function (b, d) { b.value = a.a.c(d()) } }
            })(); a.d.css = {
                update: function (b, d) {
                    var c = a.a.c(d()); null !== c && "object" == typeof c ? a.a.D(c, function (c, d) { d = a.a.c(d); a.a.bb(b, c, d) }) : (c = a.a.$a(String(c || "")), a.a.bb(b, b.__ko__cssValue,
                    !1), b.__ko__cssValue = c, a.a.bb(b, c, !0))
                }
            }; a.d.enable = { update: function (b, d) { var c = a.a.c(d()); c && b.disabled ? b.removeAttribute("disabled") : c || b.disabled || (b.disabled = !0) } }; a.d.disable = { update: function (b, d) { a.d.enable.update(b, function () { return !a.a.c(d()) }) } }; a.d.event = {
                init: function (b, d, c, e, f) {
                    var g = d() || {}; a.a.D(g, function (g) {
                        "string" == typeof g && a.a.p(b, g, function (b) {
                            var m, h = d()[g]; if (h) {
                                try { var r = a.a.V(arguments); e = f.$data; r.unshift(e); m = h.apply(e, r) } finally {
                                    !0 !== m && (b.preventDefault ? b.preventDefault() :
                                    b.returnValue = !1)
                                } !1 === c.get(g + "Bubble") && (b.cancelBubble = !0, b.stopPropagation && b.stopPropagation())
                            }
                        })
                    })
                }
            }; a.d.foreach = {
                ic: function (b) { return function () { var d = b(), c = a.a.zb(d); if (!c || "number" == typeof c.length) return { foreach: d, templateEngine: a.W.sb }; a.a.c(d); return { foreach: c.data, as: c.as, includeDestroyed: c.includeDestroyed, afterAdd: c.afterAdd, beforeRemove: c.beforeRemove, afterRender: c.afterRender, beforeMove: c.beforeMove, afterMove: c.afterMove, templateEngine: a.W.sb } } }, init: function (b, d) {
                    return a.d.template.init(b,
                    a.d.foreach.ic(d))
                }, update: function (b, d, c, e, f) { return a.d.template.update(b, a.d.foreach.ic(d), c, e, f) }
            }; a.h.ta.foreach = !1; a.f.Z.foreach = !0; a.d.hasfocus = {
                init: function (b, d, c) {
                    function e(e) { b.__ko_hasfocusUpdating = !0; var f = b.ownerDocument; if ("activeElement" in f) { var g; try { g = f.activeElement } catch (h) { g = f.body } e = g === b } f = d(); a.h.Ea(f, c, "hasfocus", e, !0); b.__ko_hasfocusLastValue = e; b.__ko_hasfocusUpdating = !1 } var f = e.bind(null, !0), g = e.bind(null, !1); a.a.p(b, "focus", f); a.a.p(b, "focusin", f); a.a.p(b, "blur", g); a.a.p(b,
                    "focusout", g)
                }, update: function (b, d) { var c = !!a.a.c(d()); b.__ko_hasfocusUpdating || b.__ko_hasfocusLastValue === c || (c ? b.focus() : b.blur(), !c && b.__ko_hasfocusLastValue && b.ownerDocument.body.focus(), a.l.w(a.a.Da, null, [b, c ? "focusin" : "focusout"])) }
            }; a.h.ea.hasfocus = !0; a.d.hasFocus = a.d.hasfocus; a.h.ea.hasFocus = !0; a.d.html = { init: function () { return { controlsDescendantBindings: !0 } }, update: function (b, d) { a.a.Cb(b, d()) } }; K("if"); K("ifnot", !1, !0); K("with", !0, !1, function (a, d) { return a.createChildContext(d) }); var L = {};
            a.d.options = {
                init: function (b) { if ("select" !== a.a.A(b)) throw Error("options binding applies only to SELECT elements"); for (; 0 < b.length;) b.remove(0); return { controlsDescendantBindings: !0 } }, update: function (b, d, c) {
                    function e() { return a.a.Ka(b.options, function (a) { return a.selected }) } function f(a, b, c) { var d = typeof b; return "function" == d ? b(a) : "string" == d ? a[b] : c } function g(d, e) {
                        if (A && h) a.j.ha(b, a.a.c(c.get("value")), !0); else if (p.length) {
                            var f = 0 <= a.a.o(p, a.j.u(e[0])); a.a.sc(e[0], f); A && !f && a.l.w(a.a.Da, null, [b,
                            "change"])
                        }
                    } var k = b.multiple, l = 0 != b.length && k ? b.scrollTop : null, m = a.a.c(d()), h = c.get("valueAllowUnset") && c.has("value"), r = c.get("optionsIncludeDestroyed"); d = {}; var q, p = []; h || (k ? p = a.a.fb(e(), a.j.u) : 0 <= b.selectedIndex && p.push(a.j.u(b.options[b.selectedIndex]))); m && ("undefined" == typeof m.length && (m = [m]), q = a.a.Ka(m, function (b) { return r || b === n || null === b || !a.a.c(b._destroy) }), c.has("optionsCaption") && (m = a.a.c(c.get("optionsCaption")), null !== m && m !== n && q.unshift(L))); var A = !1; d.beforeRemove = function (a) { b.removeChild(a) };
                    m = g; c.has("optionsAfterRender") && "function" == typeof c.get("optionsAfterRender") && (m = function (b, d) { g(0, d); a.l.w(c.get("optionsAfterRender"), null, [d[0], b !== L ? b : n]) }); a.a.Bb(b, q, function (d, e, g) { g.length && (p = !h && g[0].selected ? [a.j.u(g[0])] : [], A = !0); e = b.ownerDocument.createElement("option"); d === L ? (a.a.Za(e, c.get("optionsCaption")), a.j.ha(e, n)) : (g = f(d, c.get("optionsValue"), d), a.j.ha(e, a.a.c(g)), d = f(d, c.get("optionsText"), g), a.a.Za(e, d)); return [e] }, d, m); a.l.w(function () {
                        h ? a.j.ha(b, a.a.c(c.get("value")),
                        !0) : (k ? p.length && e().length < p.length : p.length && 0 <= b.selectedIndex ? a.j.u(b.options[b.selectedIndex]) !== p[0] : p.length || 0 <= b.selectedIndex) && a.a.Da(b, "change")
                    }); a.a.Nc(b); l && 20 < Math.abs(l - b.scrollTop) && (b.scrollTop = l)
                }
            }; a.d.options.xb = a.a.e.I(); a.d.selectedOptions = {
                after: ["options", "foreach"], init: function (b, d, c) { a.a.p(b, "change", function () { var e = d(), f = []; a.a.q(b.getElementsByTagName("option"), function (b) { b.selected && f.push(a.j.u(b)) }); a.h.Ea(e, c, "selectedOptions", f) }) }, update: function (b, d) {
                    if ("select" !=
                    a.a.A(b)) throw Error("values binding applies only to SELECT elements"); var c = a.a.c(d()), e = b.scrollTop; c && "number" == typeof c.length && a.a.q(b.getElementsByTagName("option"), function (b) { var d = 0 <= a.a.o(c, a.j.u(b)); b.selected != d && a.a.sc(b, d) }); b.scrollTop = e
                }
            }; a.h.ea.selectedOptions = !0; a.d.style = { update: function (b, d) { var c = a.a.c(d() || {}); a.a.D(c, function (c, d) { d = a.a.c(d); if (null === d || d === n || !1 === d) d = ""; b.style[c] = d }) } }; a.d.submit = {
                init: function (b, d, c, e, f) {
                    if ("function" != typeof d()) throw Error("The value for a submit binding must be a function");
                    a.a.p(b, "submit", function (a) { var c, e = d(); try { c = e.call(f.$data, b) } finally { !0 !== c && (a.preventDefault ? a.preventDefault() : a.returnValue = !1) } })
                }
            }; a.d.text = { init: function () { return { controlsDescendantBindings: !0 } }, update: function (b, d) { a.a.Za(b, d()) } }; a.f.Z.text = !0; (function () {
                if (w && w.navigator) var b = function (a) { if (a) return parseFloat(a[1]) }, d = w.opera && w.opera.version && parseInt(w.opera.version()), c = w.navigator.userAgent, e = b(c.match(/^(?:(?!chrome).)*version\/([^ ]*) safari/i)), f = b(c.match(/Firefox\/([^ ]*)/));
                if (10 > a.a.C) var g = a.a.e.I(), k = a.a.e.I(), l = function (b) { var c = this.activeElement; (c = c && a.a.e.get(c, k)) && c(b) }, m = function (b, c) { var d = b.ownerDocument; a.a.e.get(d, g) || (a.a.e.set(d, g, !0), a.a.p(d, "selectionchange", l)); a.a.e.set(b, k, c) }; a.d.textInput = {
                    init: function (b, c, g) {
                        function l(c, d) { a.a.p(b, c, d) } function k() { var d = a.a.c(c()); if (null === d || d === n) d = ""; v !== n && d === v ? a.a.setTimeout(k, 4) : b.value !== d && (u = d, b.value = d) } function y() { s || (v = b.value, s = a.a.setTimeout(t, 4)) } function t() {
                            clearTimeout(s); v = s = n; var d =
                            b.value; u !== d && (u = d, a.h.Ea(c(), g, "textInput", d))
                        } var u = b.value, s, v, w = 9 == a.a.C ? y : t; 10 > a.a.C ? (l("propertychange", function (a) { "value" === a.propertyName && w(a) }), 8 == a.a.C && (l("keyup", t), l("keydown", t)), 8 <= a.a.C && (m(b, w), l("dragend", y))) : (l("input", t), 5 > e && "textarea" === a.a.A(b) ? (l("keydown", y), l("paste", y), l("cut", y)) : 11 > d ? l("keydown", y) : 4 > f && (l("DOMAutoComplete", t), l("dragdrop", t), l("drop", t))); l("change", t); a.m(k, null, { i: b })
                    }
                }; a.h.ea.textInput = !0; a.d.textinput = {
                    preprocess: function (a, b, c) {
                        c("textInput",
                        a)
                    }
                }
            })(); a.d.uniqueName = { init: function (b, d) { if (d()) { var c = "ko_unique_" + ++a.d.uniqueName.Ic; a.a.rc(b, c) } } }; a.d.uniqueName.Ic = 0; a.d.value = {
                after: ["options", "foreach"], init: function (b, d, c) {
                    if ("input" != b.tagName.toLowerCase() || "checkbox" != b.type && "radio" != b.type) {
                        var e = ["change"], f = c.get("valueUpdate"), g = !1, k = null; f && ("string" == typeof f && (f = [f]), a.a.ra(e, f), e = a.a.Tb(e)); var l = function () { k = null; g = !1; var e = d(), f = a.j.u(b); a.h.Ea(e, c, "value", f) }; !a.a.C || "input" != b.tagName.toLowerCase() || "text" != b.type ||
                        "off" == b.autocomplete || b.form && "off" == b.form.autocomplete || -1 != a.a.o(e, "propertychange") || (a.a.p(b, "propertychange", function () { g = !0 }), a.a.p(b, "focus", function () { g = !1 }), a.a.p(b, "blur", function () { g && l() })); a.a.q(e, function (c) { var d = l; a.a.nd(c, "after") && (d = function () { k = a.j.u(b); a.a.setTimeout(l, 0) }, c = c.substring(5)); a.a.p(b, c, d) }); var m = function () {
                            var e = a.a.c(d()), f = a.j.u(b); if (null !== k && e === k) a.a.setTimeout(m, 0); else if (e !== f) if ("select" === a.a.A(b)) {
                                var g = c.get("valueAllowUnset"), f = function () {
                                    a.j.ha(b,
                                    e, g)
                                }; f(); g || e === a.j.u(b) ? a.a.setTimeout(f, 0) : a.l.w(a.a.Da, null, [b, "change"])
                            } else a.j.ha(b, e)
                        }; a.m(m, null, { i: b })
                    } else a.Ja(b, { checkedValue: d })
                }, update: function () { }
            }; a.h.ea.value = !0; a.d.visible = { update: function (b, d) { var c = a.a.c(d()), e = "none" != b.style.display; c && !e ? b.style.display = "" : !c && e && (b.style.display = "none") } }; (function (b) { a.d[b] = { init: function (d, c, e, f, g) { return a.d.event.init.call(this, d, function () { var a = {}; a[b] = c(); return a }, e, f, g) } } })("click"); a.P = function () { }; a.P.prototype.renderTemplateSource =
            function () { throw Error("Override renderTemplateSource"); }; a.P.prototype.createJavaScriptEvaluatorBlock = function () { throw Error("Override createJavaScriptEvaluatorBlock"); }; a.P.prototype.makeTemplateSource = function (b, d) { if ("string" == typeof b) { d = d || u; var c = d.getElementById(b); if (!c) throw Error("Cannot find template with ID " + b); return new a.v.n(c) } if (1 == b.nodeType || 8 == b.nodeType) return new a.v.qa(b); throw Error("Unknown template type: " + b); }; a.P.prototype.renderTemplate = function (a, d, c, e) {
                a = this.makeTemplateSource(a,
                e); return this.renderTemplateSource(a, d, c, e)
            }; a.P.prototype.isTemplateRewritten = function (a, d) { return !1 === this.allowTemplateRewriting ? !0 : this.makeTemplateSource(a, d).data("isRewritten") }; a.P.prototype.rewriteTemplate = function (a, d, c) { a = this.makeTemplateSource(a, c); d = d(a.text()); a.text(d); a.data("isRewritten", !0) }; a.b("templateEngine", a.P); a.Gb = function () {
                function b(b, c, d, k) {
                    b = a.h.yb(b); for (var l = a.h.ta, m = 0; m < b.length; m++) {
                        var h = b[m].key; if (l.hasOwnProperty(h)) {
                            var r = l[h]; if ("function" === typeof r) {
                                if (h =
                                r(b[m].value)) throw Error(h);
                            } else if (!r) throw Error("This template engine does not support the '" + h + "' binding within its templates");
                        }
                    } d = "ko.__tr_ambtns(function($context,$element){return(function(){return{ " + a.h.Ua(b, { valueAccessors: !0 }) + " } })()},'" + d.toLowerCase() + "')"; return k.createJavaScriptEvaluatorBlock(d) + c
                } var d = /(<([a-z]+\d*)(?:\s+(?!data-bind\s*=\s*)[a-z0-9\-]+(?:=(?:\"[^\"]*\"|\'[^\']*\'|[^>]*))?)*\s+)data-bind\s*=\s*(["'])([\s\S]*?)\3/gi, c = /\x3c!--\s*ko\b\s*([\s\S]*?)\s*--\x3e/g; return {
                    Oc: function (b,
                    c, d) { c.isTemplateRewritten(b, d) || c.rewriteTemplate(b, function (b) { return a.Gb.dd(b, c) }, d) }, dd: function (a, f) { return a.replace(d, function (a, c, d, e, h) { return b(h, c, d, f) }).replace(c, function (a, c) { return b(c, "\x3c!-- ko --\x3e", "#comment", f) }) }, Ec: function (b, c) { return a.N.wb(function (d, k) { var l = d.nextSibling; l && l.nodeName.toLowerCase() === c && a.Ja(l, b, k) }) }
                }
            }(); a.b("__tr_ambtns", a.Gb.Ec); (function () {
                a.v = {}; a.v.n = function (b) {
                    if (this.n = b) {
                        var d = a.a.A(b); this.ab = "script" === d ? 1 : "textarea" === d ? 2 : "template" == d &&
                        b.content && 11 === b.content.nodeType ? 3 : 4
                    }
                }; a.v.n.prototype.text = function () { var b = 1 === this.ab ? "text" : 2 === this.ab ? "value" : "innerHTML"; if (0 == arguments.length) return this.n[b]; var d = arguments[0]; "innerHTML" === b ? a.a.Cb(this.n, d) : this.n[b] = d }; var b = a.a.e.I() + "_"; a.v.n.prototype.data = function (c) { if (1 === arguments.length) return a.a.e.get(this.n, b + c); a.a.e.set(this.n, b + c, arguments[1]) }; var d = a.a.e.I(); a.v.n.prototype.nodes = function () {
                    var b = this.n; if (0 == arguments.length) return (a.a.e.get(b, d) || {}).jb || (3 === this.ab ?
                    b.content : 4 === this.ab ? b : n); a.a.e.set(b, d, { jb: arguments[0] })
                }; a.v.qa = function (a) { this.n = a }; a.v.qa.prototype = new a.v.n; a.v.qa.prototype.text = function () { if (0 == arguments.length) { var b = a.a.e.get(this.n, d) || {}; b.Hb === n && b.jb && (b.Hb = b.jb.innerHTML); return b.Hb } a.a.e.set(this.n, d, { Hb: arguments[0] }) }; a.b("templateSources", a.v); a.b("templateSources.domElement", a.v.n); a.b("templateSources.anonymousTemplate", a.v.qa)
            })(); (function () {
                function b(b, c, d) {
                    var e; for (c = a.f.nextSibling(c) ; b && (e = b) !== c;) b = a.f.nextSibling(e),
                    d(e, b)
                } function d(c, d) { if (c.length) { var e = c[0], f = c[c.length - 1], g = e.parentNode, k = a.R.instance, n = k.preprocessNode; if (n) { b(e, f, function (a, b) { var c = a.previousSibling, d = n.call(k, a); d && (a === e && (e = d[0] || b), a === f && (f = d[d.length - 1] || c)) }); c.length = 0; if (!e) return; e === f ? c.push(e) : (c.push(e, f), a.a.za(c, g)) } b(e, f, function (b) { 1 !== b.nodeType && 8 !== b.nodeType || a.Rb(d, b) }); b(e, f, function (b) { 1 !== b.nodeType && 8 !== b.nodeType || a.N.yc(b, [d]) }); a.a.za(c, g) } } function c(a) { return a.nodeType ? a : 0 < a.length ? a[0] : null } function e(b,
                e, f, k, q) {
                    q = q || {}; var p = (b && c(b) || f || {}).ownerDocument, n = q.templateEngine || g; a.Gb.Oc(f, n, p); f = n.renderTemplate(f, k, q, p); if ("number" != typeof f.length || 0 < f.length && "number" != typeof f[0].nodeType) throw Error("Template engine must return an array of DOM nodes"); p = !1; switch (e) { case "replaceChildren": a.f.da(b, f); p = !0; break; case "replaceNode": a.a.qc(b, f); p = !0; break; case "ignoreTargetNode": break; default: throw Error("Unknown renderMode: " + e); } p && (d(f, k), q.afterRender && a.l.w(q.afterRender, null, [f, k.$data]));
                    return f
                } function f(b, c, d) { return a.H(b) ? b() : "function" === typeof b ? b(c, d) : b } var g; a.Db = function (b) { if (b != n && !(b instanceof a.P)) throw Error("templateEngine must inherit from ko.templateEngine"); g = b }; a.Ab = function (b, d, h, k, q) {
                    h = h || {}; if ((h.templateEngine || g) == n) throw Error("Set a template engine before calling renderTemplate"); q = q || "replaceChildren"; if (k) {
                        var p = c(k); return a.B(function () { var g = d && d instanceof a.U ? d : new a.U(a.a.c(d)), n = f(b, g.$data, g), g = e(k, q, n, g, h); "replaceNode" == q && (k = g, p = c(k)) }, null,
                        { wa: function () { return !p || !a.a.nb(p) }, i: p && "replaceNode" == q ? p.parentNode : p })
                    } return a.N.wb(function (c) { a.Ab(b, d, h, c, "replaceNode") })
                }; a.kd = function (b, c, g, k, q) {
                    function p(a, b) { d(b, s); g.afterRender && g.afterRender(b, a); s = null } function u(a, c) { s = q.createChildContext(a, g.as, function (a) { a.$index = c }); var d = f(b, a, s); return e(null, "ignoreTargetNode", d, s, g) } var s; return a.B(function () {
                        var b = a.a.c(c) || []; "undefined" == typeof b.length && (b = [b]); b = a.a.Ka(b, function (b) { return g.includeDestroyed || b === n || null === b || !a.a.c(b._destroy) });
                        a.l.w(a.a.Bb, null, [k, b, u, g, p])
                    }, null, { i: k })
                }; var k = a.a.e.I(); a.d.template = {
                    init: function (b, c) { var d = a.a.c(c()); if ("string" == typeof d || d.name) a.f.xa(b); else { if ("nodes" in d) { if (d = d.nodes || [], a.H(d)) throw Error('The "nodes" option must be a plain, non-observable array.'); } else d = a.f.childNodes(b); d = a.a.jc(d); (new a.v.qa(b)).nodes(d) } return { controlsDescendantBindings: !0 } }, update: function (b, c, d, e, f) {
                        var g = c(), s; c = a.a.c(g); d = !0; e = null; "string" == typeof c ? c = {} : (g = c.name, "if" in c && (d = a.a.c(c["if"])), d && "ifnot" in
                        c && (d = !a.a.c(c.ifnot)), s = a.a.c(c.data)); "foreach" in c ? e = a.kd(g || b, d && c.foreach || [], c, b, f) : d ? (f = "data" in c ? f.createChildContext(s, c.as) : f, e = a.Ab(g || b, f, c, b)) : a.f.xa(b); f = e; (s = a.a.e.get(b, k)) && "function" == typeof s.k && s.k(); a.a.e.set(b, k, f && f.ba() ? f : n)
                    }
                }; a.h.ta.template = function (b) { b = a.h.yb(b); return 1 == b.length && b[0].unknown || a.h.ad(b, "name") ? null : "This template engine does not support anonymous templates nested within its templates" }; a.f.Z.template = !0
            })(); a.b("setTemplateEngine", a.Db); a.b("renderTemplate",
            a.Ab); a.a.dc = function (a, d, c) { if (a.length && d.length) { var e, f, g, k, l; for (e = f = 0; (!c || e < c) && (k = a[f]) ; ++f) { for (g = 0; l = d[g]; ++g) if (k.value === l.value) { k.moved = l.index; l.moved = k.index; d.splice(g, 1); e = g = 0; break } e += g } } }; a.a.ib = function () {
                function b(b, c, e, f, g) {
                    var k = Math.min, l = Math.max, m = [], h, n = b.length, q, p = c.length, s = p - n || 1, u = n + p + 1, t, v, w; for (h = 0; h <= n; h++) for (v = t, m.push(t = []), w = k(p, h + s), q = l(0, h - 1) ; q <= w; q++) t[q] = q ? h ? b[h - 1] === c[q - 1] ? v[q - 1] : k(v[q] || u, t[q - 1] || u) + 1 : q + 1 : h + 1; k = []; l = []; s = []; h = n; for (q = p; h || q;) p = m[h][q] -
                    1, q && p === m[h][q - 1] ? l.push(k[k.length] = { status: e, value: c[--q], index: q }) : h && p === m[h - 1][q] ? s.push(k[k.length] = { status: f, value: b[--h], index: h }) : (--q, --h, g.sparse || k.push({ status: "retained", value: c[q] })); a.a.dc(s, l, !g.dontLimitMoves && 10 * n); return k.reverse()
                } return function (a, c, e) { e = "boolean" === typeof e ? { dontLimitMoves: e } : e || {}; a = a || []; c = c || []; return a.length < c.length ? b(a, c, "added", "deleted", e) : b(c, a, "deleted", "added", e) }
            }(); a.b("utils.compareArrays", a.a.ib); (function () {
                function b(b, c, d, k, l) {
                    var m = [],
                    h = a.B(function () { var h = c(d, l, a.a.za(m, b)) || []; 0 < m.length && (a.a.qc(m, h), k && a.l.w(k, null, [d, h, l])); m.length = 0; a.a.ra(m, h) }, null, { i: b, wa: function () { return !a.a.Qb(m) } }); return { ca: m, B: h.ba() ? h : n }
                } var d = a.a.e.I(), c = a.a.e.I(); a.a.Bb = function (e, f, g, k, l) {
                    function m(b, c) { x = q[c]; v !== c && (D[b] = x); x.qb(v++); a.a.za(x.ca, e); u.push(x); z.push(x) } function h(b, c) { if (b) for (var d = 0, e = c.length; d < e; d++) c[d] && a.a.q(c[d].ca, function (a) { b(a, d, c[d].ja) }) } f = f || []; k = k || {}; var r = a.a.e.get(e, d) === n, q = a.a.e.get(e, d) || [], p = a.a.fb(q,
                    function (a) { return a.ja }), s = a.a.ib(p, f, k.dontLimitMoves), u = [], t = 0, v = 0, w = [], z = []; f = []; for (var D = [], p = [], x, C = 0, B, E; B = s[C]; C++) switch (E = B.moved, B.status) { case "deleted": E === n && (x = q[t], x.B && (x.B.k(), x.B = n), w.push.apply(w, a.a.za(x.ca, e) || []), k.beforeRemove && x.ca.length && (u.push(x), z.push(x), x.ja !== c && (f[C] = x))); t++; break; case "retained": m(C, t++); break; case "added": E !== n ? m(C, E) : (x = { ja: B.value, qb: a.O(v++) }, u.push(x), z.push(x), r || (p[C] = x)) } a.a.e.set(e, d, u); h(k.beforeMove, D); a.a.q(w, k.beforeRemove ? a.$ : a.removeNode);
                    for (var C = 0, r = a.f.firstChild(e), F; x = z[C]; C++) { x.ca || a.a.extend(x, b(e, g, x.ja, l, x.qb)); for (t = 0; s = x.ca[t]; r = s.nextSibling, F = s, t++) s !== r && a.f.gc(e, s, F); !x.Wc && l && (l(x.ja, x.ca, x.qb), x.Wc = !0) } h(k.beforeRemove, f); for (C = 0; C < f.length; ++C) f[C] && (f[C].ja = c); h(k.afterMove, D); h(k.afterAdd, p)
                }
            })(); a.b("utils.setDomNodeChildrenFromArrayMapping", a.a.Bb); a.W = function () { this.allowTemplateRewriting = !1 }; a.W.prototype = new a.P; a.W.prototype.renderTemplateSource = function (b, d, c, e) {
                if (d = (9 > a.a.C ? 0 : b.nodes) ? b.nodes() : null) return a.a.V(d.cloneNode(!0).childNodes);
                b = b.text(); return a.a.ma(b, e)
            }; a.W.sb = new a.W; a.Db(a.W.sb); a.b("nativeTemplateEngine", a.W); (function () {
                a.vb = function () {
                    var a = this.$c = function () { if (!s || !s.tmpl) return 0; try { if (0 <= s.tmpl.tag.tmpl.open.toString().indexOf("__")) return 2 } catch (a) { } return 1 }(); this.renderTemplateSource = function (b, e, f, g) {
                        g = g || u; f = f || {}; if (2 > a) throw Error("Your version of jQuery.tmpl is too old. Please upgrade to jQuery.tmpl 1.0.0pre or later."); var k = b.data("precompiled"); k || (k = b.text() || "", k = s.template(null, "{{ko_with $item.koBindingContext}}" +
                        k + "{{/ko_with}}"), b.data("precompiled", k)); b = [e.$data]; e = s.extend({ koBindingContext: e }, f.templateOptions); e = s.tmpl(k, b, e); e.appendTo(g.createElement("div")); s.fragments = {}; return e
                    }; this.createJavaScriptEvaluatorBlock = function (a) { return "{{ko_code ((function() { return " + a + " })()) }}" }; this.addTemplate = function (a, b) { u.write("<script type='text/html' id='" + a + "'>" + b + "\x3c/script>") }; 0 < a && (s.tmpl.tag.ko_code = { open: "__.push($1 || '');" }, s.tmpl.tag.ko_with = { open: "with($1) {", close: "} " })
                }; a.vb.prototype =
                new a.P; var b = new a.vb; 0 < b.$c && a.Db(b); a.b("jqueryTmplTemplateEngine", a.vb)
            })()
        })
    })();
})();