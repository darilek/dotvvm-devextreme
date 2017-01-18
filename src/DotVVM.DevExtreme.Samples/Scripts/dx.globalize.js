(function ($, DX, Globalize) {
    DX.localization.number.resetInjection();
    DX.localization.number.inject({
        _formatNumberCore: function (value, format, formatConfig) {
            if (format === "exponential") {
                return this.callBase.apply(this, arguments);
            }
            return Globalize.format(value, this._normalizeFormatConfig(format, formatConfig));
        },
        _patternByFormat: function (format) {
            return {
                fixedpoint: "n",
                decimal: "d",
                percent: "p",
                currency: "c"
            }[format];
        },
        _normalizeFormatConfig: function (format, formatConfig, value) {
            return this._patternByFormat(format) + formatConfig.precision;
        },
        format: function (value, format) {
            if (typeof value !== "number") {
                return value;
            }
            var isGlobalizeFormat = /^(n|d|p|c)[0-9]{0,2}$/i.test(format);
            if (isGlobalizeFormat) {
                return Globalize.format(value, format);
            }
            format = this._normalizeFormat(format);
            return this.callBase.apply(this, arguments);
        },
        parse: function (text, format) {
            if (!text) {
                return;
            }
            if (format && format.parser) {
                return format.parser(text);
            }
            return Globalize.parseFloat(text);
        },
        getOpenXmlCurrencyFormat: function () {
            var currency = Globalize.cultures[Globalize.cultureSelector].numberFormat.currency, i, result, symbol, encodeSymbols;
            if ($.type(currency.pattern) === "array") {
                encodeSymbols = {
                    n: "#,##0{0}",
                    "'": "\\'",
                    "\\(": "\\(",
                    "\\)": "\\)",
                    " ": "\\ ",
                    '"': "&quot;",
                    "\\$": currency.symbol
                };
                result = currency.pattern.slice();
                for (symbol in encodeSymbols) {
                    if (encodeSymbols.hasOwnProperty(symbol)) {
                        for (i = 0; i < result.length; i++) {
                            result[i] = result[i].replace(new RegExp(symbol, "g"), encodeSymbols[symbol]);
                        }
                    }
                }
                return result.length === 2 ? result[1] + "_);" + result[0] : result[0];
            }
        }
    });
})(jQuery, DevExpress, Globalize);

(function ($, DX, Globalize) {
    var DateTimeFormat = {
        longdate: {
            shortcut: "D"
        },
        longtime: {
            shortcut: "T"
        },
        monthandday: {
            shortcut: "M"
        },
        monthandyear: {
            shortcut: "Y"
        },
        shortdate: {
            shortcut: "d"
        },
        shorttime: {
            shortcut: "t"
        },
        second: "ss",
        minute: "mm",
        hour: "HH",
        millisecond: "fff",
        day: "dd",
        dayofweek: "dddd",
        month: "MMMM",
        year: "yyyy",
        shortyear: "yy",
        longdatelongtime: {
            parts: ["longdate", "longtime"]
        },
        shortdateshorttime: {
            parts: ["shortdate", "shorttime"]
        },
        mediumdatemediumtime: {
            parts: ["monthandday", "shorttime"]
        },
        "datetime-local": "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
    };
    DX.localization.date.resetInjection();
    DX.localization.date.inject({
        getPatternByFormat: function (format) {
            var that = this, globalizeFormat = DateTimeFormat[format.toLowerCase()];
            if (!globalizeFormat) {
                return;
            }
            if (globalizeFormat.shortcut) {
                return Globalize.findClosestCulture().calendar.patterns[globalizeFormat.shortcut];
            }
            if (globalizeFormat.parts) {
                return globalizeFormat.parts.map(function (part) {
                    return that.getPatternByFormat(part);
                }).join(" ");
            }
            return globalizeFormat;
        },
        getMonthNames: function (format) {
            var chooseFormat = {
                wide: function (months) {
                    return months.names;
                },
                abbreviated: function (months) {
                    return months.namesAbbr;
                },
                narrow: function (months) {
                    return months.namesAbbr.map(function (month) {
                        return month.substr(0, 1);
                    });
                }
            };
            return chooseFormat[format || "wide"](Globalize.culture().calendar.months).slice(0, -1);
        },
        getDayNames: function (format) {
            var chooseFormat = {
                wide: function (days) {
                    return days.names;
                },
                abbreviated: function (days) {
                    return days.namesAbbr;
                },
                "short": function (days) {
                    return days.namesShort;
                },
                narrow: function (days) {
                    return days.namesAbbr.map(function (day) {
                        return day.substr(0, 1);
                    });
                }
            };
            return chooseFormat[format || "wide"](Globalize.culture().calendar.days);
        },
        getTimeSeparator: function () {
            return Globalize.culture().calendar[":"];
        },
        firstDayOfWeekIndex: function () {
            return Globalize.culture().calendar.firstDay;
        },
        format: function (date, format) {
            if (!date) {
                return;
            }
            if (!format) {
                return date;
            }
            format = format.type || format;
            if (format.formatter || $.isFunction(format) || $.inArray(format.toLowerCase(), ["quarter", "quarterandyear"]) > -1) {
                return this.callBase.apply(this, arguments);
            }
            return Globalize.format(date, this.getPatternByFormat(format) || format);
        },
        parse: function (text, format) {
            format = format && format.type || format;
            if (!format) {
                return Globalize.parseDate(text);
            }
            if (format.parser || $.inArray(format.toLowerCase(), ["quarter", "quarterandyear"]) > -1) {
                return this.callBase.apply(this, arguments);
            }
            return Globalize.parseDate(text, this.getPatternByFormat(format) || format);
        }
    });
})(jQuery, DevExpress, Globalize);

(function ($, DX, Globalize) {
    var originalAddCultureInfo = Globalize.addCultureInfo, originalCulture = Globalize.culture;
    Globalize.addCultureInfo = function (culture, info) {
        var messages = {};
        messages[culture] = info.messages;
        DX.localization.message.load(messages);
    };
    Globalize.culture = function (culture) {
        return DX.localization.message.locale(culture);
    };
    DX.localization.message.resetInjection();
    DX.localization.message.inject({
        ctor: function () {
            this.load(this._dictionary);
        },
        locale: function (locale) {
            this.callBase.apply(this, arguments);
            return originalCulture.apply(Globalize, arguments);
        },
        load: function (info) {
            $.each(info, function (culture, messages) {
                originalAddCultureInfo.call(Globalize, culture, {
                    messages: messages
                });
            });
            this.callBase.apply(this, arguments);
        },
        format: function (key, value) {
            if (this._messageLoaded(key, Globalize.cultureSelector)) {
                return this.callBase(key, value, Globalize.cultureSelector);
            }
            return this.callBase(key, value);
        },
        getFormatter: function (key) {
            if (this._messageLoaded(key, Globalize.cultureSelector)) {
                return this.callBase(key, Globalize.cultureSelector);
            }
            return this.callBase(key);
        }
    });
})(jQuery, DevExpress, Globalize);
