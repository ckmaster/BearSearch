import { isNil } from '../predicate';
export var formatBoolean = function (value, _a) {
    var _b = _a === void 0 ? {} : _a, _c = _b.yes, yes = _c === void 0 ? 'Yes' : _c, _d = _b.no, no = _d === void 0 ? 'No' : _d, _e = _b.nil, nil = _e === void 0 ? '' : _e;
    if (isNil(value)) {
        return nil;
    }
    return value ? yes : no;
};
