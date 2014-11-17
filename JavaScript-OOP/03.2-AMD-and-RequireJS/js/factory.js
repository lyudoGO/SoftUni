define(["js/container", "js/section", "js/item"],
    function (Container, Section, Item) {
      "use strict";
      return {
        getContainer: function () {
          return new Container();
        },
        getSection: function (title) {
          return new Section(title);
        },
        getItem: function (content) {
          return new Item(content);
        }
    };
});