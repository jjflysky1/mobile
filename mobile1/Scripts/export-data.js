﻿/*
 Highcharts JS v7.0.1 (2018-12-19)
 Exporting module

 (c) 2010-2018 Torstein Honsi

 License: www.highcharts.com/license
*/
(function (m) { "object" === typeof module && module.exports ? module.exports = m : "function" === typeof define && define.amd ? define(function () { return m }) : m("undefined" !== typeof Highcharts ? Highcharts : void 0) })(function (m) {
    (function (a) {
        a.ajax = function (f) {
            var b = a.merge(!0, { url: !1, type: "GET", dataType: "json", success: !1, error: !1, data: !1, headers: {} }, f); f = { json: "application/json", xml: "application/xml", text: "text/plain", octet: "application/octet-stream" }; var c = new XMLHttpRequest; if (!b.url) return !1; c.open(b.type.toUpperCase(),
                b.url, !0); c.setRequestHeader("Content-Type", f[b.dataType] || f.text); a.objectEach(b.headers, function (a, f) { c.setRequestHeader(f, a) }); c.onreadystatechange = function () { var a; if (4 === c.readyState) { if (200 === c.status) { a = c.responseText; if ("json" === b.dataType) try { a = JSON.parse(a) } catch (v) { b.error && b.error(c, v); return } return b.success && b.success(a) } b.error && b.error(c, c.responseText) } }; try { b.data = JSON.stringify(b.data) } catch (k) { } c.send(b.data || !0)
        }
    })(m); (function (a) {
        var f = a.win, b = f.navigator, c = f.document, k = f.URL ||
            f.webkitURL || f, v = /Edge\/\d+/.test(b.userAgent); a.dataURLtoBlob = function (a) { if ((a = a.match(/data:([^;]*)(;base64)?,([0-9A-Za-z+/]+)/)) && 3 < a.length && f.atob && f.ArrayBuffer && f.Uint8Array && f.Blob && k.createObjectURL) { for (var c = f.atob(a[3]), b = new f.ArrayBuffer(c.length), b = new f.Uint8Array(b), g = 0; g < b.length; ++g)b[g] = c.charCodeAt(g); a = new f.Blob([b], { type: a[1] }); return k.createObjectURL(a) } }; a.downloadURL = function (e, k) {
                var q = c.createElement("a"), g; if ("string" === typeof e || e instanceof String || !b.msSaveOrOpenBlob) {
                    if (v ||
                        2E6 < e.length) if (e = a.dataURLtoBlob(e), !e) throw "Failed to convert to blob"; if (void 0 !== q.download) q.href = e, q.download = k, c.body.appendChild(q), q.click(), c.body.removeChild(q); else try { if (g = f.open(e, "chart"), void 0 === g || null === g) throw "Failed to open window"; } catch (B) { f.location.href = e }
                } else b.msSaveOrOpenBlob(e, k)
            }
    })(m); (function (a) {
        function f(a, b) { if (k.Blob && k.navigator.msSaveOrOpenBlob) return new k.Blob(["\ufeff" + a], { type: b }) } var b = a.defined, c = a.pick, k = a.win, v = k.document, e = a.seriesTypes, m = a.downloadURL;
        a.setOptions({ exporting: { csv: { columnHeaderFormatter: null, dateFormat: "%Y-%m-%d %H:%M:%S", decimalPoint: null, itemDelimiter: null, lineDelimiter: "\n" }, showTable: !1, useMultiLevelHeaders: !0, useRowspanHeaders: !0 }, lang: { downloadCSV: "Download CSV", downloadXLS: "Download XLS", openInCloud: "Open in Highcharts Cloud", viewData: "View data table" } }); a.addEvent(a.Chart, "render", function () { this.options && this.options.exporting && this.options.exporting.showTable && this.viewData() }); a.Chart.prototype.setUpKeyToAxis = function () {
            e.arearange &&
                (e.arearange.prototype.keyToAxis = { low: "y", high: "y" }); e.gantt && (e.gantt.prototype.keyToAxis = { start: "x", end: "x" })
        }; a.Chart.prototype.getDataRows = function (g) {
            var f = this.time, e = this.options.exporting && this.options.exporting.csv || {}, h, l = this.xAxis, t = {}, k = [], n, m = [], p = [], y, w, u, C = function (d, b, h) {
                if (e.columnHeaderFormatter) { var u = e.columnHeaderFormatter(d, b, h); if (!1 !== u) return u } return d ? d instanceof a.Axis ? d.options.title && d.options.title.text || (d.isDatetimeAxis ? "DateTime" : "Category") : g ? {
                    columnTitle: 1 < h ?
                        b : d.name, topLevelColumnTitle: d.name
                } : d.name + (1 < h ? " (" + b + ")" : "") : "Category"
            }, z = []; w = 0; this.setUpKeyToAxis(); this.series.forEach(function (d) {
                var b = d.options.keys || d.pointArrayMap || ["y"], h = b.length, u = !d.requireSorting && {}, x = {}, B = {}, n = l.indexOf(d.xAxis), k, r; b.forEach(function (a) { var b = (d.keyToAxis && d.keyToAxis[a] || a) + "Axis"; x[a] = d[b] && d[b].categories || []; B[a] = d[b] && d[b].isDatetimeAxis }); if (!1 !== d.options.includeInCSVExport && !d.options.isInternal && !1 !== d.visible) {
                    a.find(z, function (d) { return d[0] === n }) ||
                        z.push([n, w]); for (r = 0; r < h;)y = C(d, b[r], b.length), p.push(y.columnTitle || y), g && m.push(y.topLevelColumnTitle || y), r++; k = { chart: d.chart, autoIncrement: d.autoIncrement, options: d.options, pointArrayMap: d.pointArrayMap }; d.options.data.forEach(function (a, g) {
                            var l, p; p = { series: k }; d.pointClass.prototype.applyOptions.apply(p, [a]); a = p.x; l = d.data[g] && d.data[g].name; u && (u[a] && (a += "|" + g), u[a] = !0); r = 0; d.xAxis && "name" !== d.exportKey || (a = l); t[a] || (t[a] = [], t[a].xValues = []); t[a].x = p.x; t[a].name = l; for (t[a].xValues[n] = p.x; r <
                                h;)g = b[r], l = p[g], t[a][w + r] = c(x[g][l], B[g] ? f.dateFormat(e.dateFormat, l) : null, l), r++
                        }); w += r
                }
            }); for (n in t) t.hasOwnProperty(n) && k.push(t[n]); var x, A; n = g ? [m, p] : [p]; for (w = z.length; w--;)x = z[w][0], A = z[w][1], h = l[x], k.sort(function (a, b) { return a.xValues[x] - b.xValues[x] }), u = C(h), n[0].splice(A, 0, u), g && n[1] && n[1].splice(A, 0, u), k.forEach(function (a) {
                var d = a.name; h && !b(d) && (h.isDatetimeAxis ? (a.x instanceof Date && (a.x = a.x.getTime()), d = f.dateFormat(e.dateFormat, a.x)) : d = h.categories ? c(h.names[a.x], h.categories[a.x],
                    a.x) : a.x); a.splice(A, 0, d)
            }); n = n.concat(k); a.fireEvent(this, "exportData", { dataRows: n }); return n
        }; a.Chart.prototype.getCSV = function (a) {
            var b = "", g = this.getDataRows(), h = this.options.exporting.csv, f = c(h.decimalPoint, "," !== h.itemDelimiter && a ? (1.1).toLocaleString()[1] : "."), e = c(h.itemDelimiter, "," === f ? ";" : ","), k = h.lineDelimiter; g.forEach(function (a, h) {
                for (var c, l = a.length; l--;)c = a[l], "string" === typeof c && (c = '"' + c + '"'), "number" === typeof c && "." !== f && (c = c.toString().replace(".", f)), a[l] = c; b += a.join(e); h < g.length -
                    1 && (b += k)
            }); return b
        }; a.Chart.prototype.getTable = function (a) {
            var b = "\x3ctable\x3e", g = this.options, h = a ? (1.1).toLocaleString()[1] : ".", f = c(g.exporting.useMultiLevelHeaders, !0); a = this.getDataRows(f); var e = 0, k = f ? a.shift() : null, n = a.shift(), m = function (a, b, g, f) { var e = c(f, ""); b = "text" + (b ? " " + b : ""); "number" === typeof e ? (e = e.toString(), "," === h && (e = e.replace(".", h)), b = "number") : f || (b = "empty"); return "\x3c" + a + (g ? " " + g : "") + ' class\x3d"' + b + '"\x3e' + e + "\x3c/" + a + "\x3e" }; !1 !== g.exporting.tableCaption && (b += '\x3ccaption class\x3d"highcharts-table-caption"\x3e' +
                c(g.exporting.tableCaption, g.title.text ? g.title.text.replace(/&/g, "\x26amp;").replace(/</g, "\x26lt;").replace(/>/g, "\x26gt;").replace(/"/g, "\x26quot;").replace(/'/g, "\x26#x27;").replace(/\//g, "\x26#x2F;") : "Chart") + "\x3c/caption\x3e"); for (var p = 0, q = a.length; p < q; ++p)a[p].length > e && (e = a[p].length); b += function (a, b, e) {
                    var h = "\x3cthead\x3e", c = 0; e = e || b && b.length; var k, d, l = 0; if (d = f && a && b) { a: if (d = a.length, b.length === d) { for (; d--;)if (a[d] !== b[d]) { d = !1; break a } d = !0 } else d = !1; d = !d } if (d) {
                        for (h += "\x3ctr\x3e"; c <
                            e; ++c)d = a[c], k = a[c + 1], d === k ? ++l : l ? (h += m("th", "highcharts-table-topheading", 'scope\x3d"col" colspan\x3d"' + (l + 1) + '"', d), l = 0) : (d === b[c] ? g.exporting.useRowspanHeaders ? (k = 2, delete b[c]) : (k = 1, b[c] = "") : k = 1, h += m("th", "highcharts-table-topheading", 'scope\x3d"col"' + (1 < k ? ' valign\x3d"top" rowspan\x3d"' + k + '"' : ""), d)); h += "\x3c/tr\x3e"
                    } if (b) { h += "\x3ctr\x3e"; c = 0; for (e = b.length; c < e; ++c)void 0 !== b[c] && (h += m("th", null, 'scope\x3d"col"', b[c])); h += "\x3c/tr\x3e" } return h + "\x3c/thead\x3e"
                }(k, n, Math.max(e, n.length)); b +=
                    "\x3ctbody\x3e"; a.forEach(function (a) { b += "\x3ctr\x3e"; for (var c = 0; c < e; c++)b += m(c ? "td" : "th", null, c ? "" : 'scope\x3d"row"', a[c]); b += "\x3c/tr\x3e" }); return b += "\x3c/tbody\x3e\x3c/table\x3e"
        }; a.Chart.prototype.downloadCSV = function () { var a = this.getCSV(!0); m(f(a, "text/csv") || "data:text/csv,\ufeff" + encodeURIComponent(a), this.getFilename() + ".csv") }; a.Chart.prototype.downloadXLS = function () {
            var a = '\x3chtml xmlns:o\x3d"urn:schemas-microsoft-com:office:office" xmlns:x\x3d"urn:schemas-microsoft-com:office:excel" xmlns\x3d"http://www.w3.org/TR/REC-html40"\x3e\x3chead\x3e\x3c!--[if gte mso 9]\x3e\x3cxml\x3e\x3cx:ExcelWorkbook\x3e\x3cx:ExcelWorksheets\x3e\x3cx:ExcelWorksheet\x3e\x3cx:Name\x3eArk1\x3c/x:Name\x3e\x3cx:WorksheetOptions\x3e\x3cx:DisplayGridlines/\x3e\x3c/x:WorksheetOptions\x3e\x3c/x:ExcelWorksheet\x3e\x3c/x:ExcelWorksheets\x3e\x3c/x:ExcelWorkbook\x3e\x3c/xml\x3e\x3c![endif]--\x3e\x3cstyle\x3etd{border:none;font-family: Calibri, sans-serif;} .number{mso-number-format:"0.00";} .text{ mso-number-format:"@";}\x3c/style\x3e\x3cmeta name\x3dProgId content\x3dExcel.Sheet\x3e\x3cmeta charset\x3dUTF-8\x3e\x3c/head\x3e\x3cbody\x3e' +
                this.getTable(!0) + "\x3c/body\x3e\x3c/html\x3e"; m(f(a, "application/vnd.ms-excel") || "data:application/vnd.ms-excel;base64," + k.btoa(unescape(encodeURIComponent(a))), this.getFilename() + ".xls")
        }; a.Chart.prototype.viewData = function () { this.dataTableDiv || (this.dataTableDiv = v.createElement("div"), this.dataTableDiv.className = "highcharts-data-table", this.renderTo.parentNode.insertBefore(this.dataTableDiv, this.renderTo.nextSibling)); this.dataTableDiv.innerHTML = this.getTable() }; a.Chart.prototype.openInCloud = function () {
            function b(c) {
                Object.keys(c).forEach(function (e) {
                    "function" ===
                        typeof c[e] && delete c[e]; a.isObject(c[e]) && b(c[e])
                })
            } var c, e; c = a.merge(this.userOptions); b(c); c = { name: c.title && c.title.text || "Chart title", options: c, settings: { constructor: "Chart", dataProvider: { csv: this.getCSV() } } }; e = JSON.stringify(c); (function () { var a = v.createElement("form"); v.body.appendChild(a); a.method = "post"; a.action = "https://cloud-api.highcharts.com/openincloud"; a.target = "_blank"; var b = v.createElement("input"); b.type = "hidden"; b.name = "chart"; b.value = e; a.appendChild(b); a.submit(); v.body.removeChild(a) })()
        };
        var q = a.getOptions().exporting; q && (a.extend(q.menuItemDefinitions, { downloadCSV: { textKey: "downloadCSV", onclick: function () { this.downloadCSV() } }, downloadXLS: { textKey: "downloadXLS", onclick: function () { this.downloadXLS() } }, viewData: { textKey: "viewData", onclick: function () { this.viewData() } }, openInCloud: { textKey: "openInCloud", onclick: function () { this.openInCloud() } } }), q.buttons.contextButton.menuItems.push("separator", "downloadCSV", "downloadXLS", "viewData", "openInCloud")); e.map && (e.map.prototype.exportKey = "name");
        e.mapbubble && (e.mapbubble.prototype.exportKey = "name"); e.treemap && (e.treemap.prototype.exportKey = "name")
    })(m)
});
//# sourceMappingURL=export-data.js.map