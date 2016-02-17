// Custom validation for Kendo Grid
window.onGridValidationError = function (args) {
    if (args.errors) {
        var grid = $("#my-kendo-grid").data("kendoGrid");
        var validationTemplate = kendo.template($("#orderDetailsValidationMessageTemplate").html());
        grid.one("dataBinding", function (e) {
            e.preventDefault();

            $.each(args.errors, function (propertyName) {
                var renderedTemplate = validationTemplate({ field: propertyName, messages: this.errors });
                grid.editable.element.find(".errors").append(renderedTemplate);
            });
        });
    }
};