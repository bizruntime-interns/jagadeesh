"use strict";
exports.__esModule = true;
function person(_a) {
    var firstname = _a.firstname, lastname = _a.lastname;
    var address = [];
    for (var _i = 1; _i < arguments.length; _i++) {
        address[_i - 1] = arguments[_i];
    }
    return firstname + "," + lastname + "," + address;
}
exports.person = person;
//# sourceMappingURL=person.js.map