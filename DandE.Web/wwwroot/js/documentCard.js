var documentCard = /** @class */ (function () {
    function documentCard(title, contents) {
        this.title = title;
        this.contents = contents;
    }
    Object.defineProperty(documentCard.prototype, "length", {
        get: function () {
            return this.contents.length;
        },
        enumerable: false,
        configurable: true
    });
    return documentCard;
}());
//# sourceMappingURL=documentCard.js.map