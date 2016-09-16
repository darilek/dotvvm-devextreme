/// <reference path="typings/knockout/knockout.d.ts" />
/// <reference path="typings/dotvvm/DotVVM.d.ts" />
/// <reference path="typings/globalize/globalize.d.ts" />
/// <reference path="typings/devextreme/devextreme.d.ts" />

declare var dotvvm_Globalize: GlobalizeStatic;

interface DotvvmGlobalize
{
    parseDate(value: string, format: string, culture?: string): Date;
}

DotvvmGlobalize.prototype.parseDate = function (value: string, format: string, culture?: string): Date
{
    if (culture)
        return dotvvm_Globalize.parseDate(value, format, culture);
    else {
        return dotvvm.globalize.parseDate(value, format);
    }
}

ko.extenders["dxDatetime"] = (target, option) => {
    target.dxDatetime = ko.computed({
        read: function () {
            // return new Date(this());
            return dotvvm.globalize.formatString("yyyy/MM/dd", this());
            //return new Date().toDateString();
        },
        write: function (value) {
            //var result = dotvvm.globalize.parseDate(value, "yyyy/MM/dd");
            var result = dotvvm.globalize.parseDate(value, "yyyy/MM/dd", "en-US");
            //var result = value.toISOString();
            //result = result.replace("Z", "0");
            this(result);
        },
        owner: target
    });
    return target;
};

ko.components.register(
    "dx-date-box",
    {
        viewModel: function (params: DevExpress.ui.dxDateBoxOptions) {
            var self = this;
            self.params = params;
            self.onChange = (e) => {
                if (this.params.onChange) {
                    this.params.onChange(e);
                }

            }
            if (ko.isObservable(params.value)) {
                params.value.extend({ dxDatetime: null });
            }
        },

        template: "<div data-bind='dxDateBox : {value : params.value.dxDatetime, disabled: params.disabled, onValueChanged: onChange}'></div>"
    }
);
