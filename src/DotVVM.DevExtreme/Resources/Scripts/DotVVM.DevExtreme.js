/// <reference path="typings/knockout/knockout.d.ts" />
/// <reference path="typings/dotvvm/DotVVM.d.ts" />
/// <reference path="typings/globalize/globalize.d.ts" />
ko.extenders["dxDatetime"] = function (target, option) {
    target.datetime = ko.computed({
        read: function () {
            // return new Date(this());
            return dotvvm.globalize.formatString("yyyy/MM/dd", this());
        },
        write: function (value) {
            //var result = dotvvm.globalize.parseDate(value, "yyyy/MM/dd");
            var result = Globalize.parseDate(value, "yyyy/MM/dd", "en-US");
            //var result = value.toISOString();
            //result = result.replace("Z", "0");
            this(result);
        },
        owner: target
    });
    return target;
};
ko.components.register("dx-date-box", {
    viewModel: function (params) {
        this.value = params.value;
        this.value.extend({ datetime: null });
    },
    template: "<div data-bind='dxDateBox : {value: value.datetime}'></div>"
});
//# sourceMappingURL=DotVVM.DevExtreme.js.map