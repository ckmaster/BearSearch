/*! Copyright Elasticsearch B.V. and/or license to Elasticsearch B.V. under one or more contributor license agreements
 * Licensed under the Elastic License; you may not use this file except in compliance with the Elastic License. */
webpackJsonp([13],{4709:function(module,exports,__webpack_require__){"use strict";__webpack_require__(131);__webpack_require__(133);__webpack_require__(134);__webpack_require__(135);__webpack_require__(136);__webpack_require__(137);__webpack_require__(138);__webpack_require__(139);__webpack_require__(140);__webpack_require__(141);__webpack_require__(142);__webpack_require__(143);__webpack_require__(144);__webpack_require__(145);__webpack_require__(146);__webpack_require__(147);__webpack_require__(148);__webpack_require__(149);__webpack_require__(150);__webpack_require__(151);__webpack_require__(152);__webpack_require__(153);__webpack_require__(154);__webpack_require__(155);__webpack_require__(156);__webpack_require__(157);__webpack_require__(158);__webpack_require__(159);__webpack_require__(160);__webpack_require__(161);__webpack_require__(162);__webpack_require__(163);__webpack_require__(164);__webpack_require__(165);__webpack_require__(166);__webpack_require__(167);__webpack_require__(168);__webpack_require__(169);__webpack_require__(170);__webpack_require__(171);__webpack_require__(172);__webpack_require__(173);__webpack_require__(174);__webpack_require__(175);__webpack_require__(176);__webpack_require__(177);__webpack_require__(178);__webpack_require__(179);__webpack_require__(180);__webpack_require__(181);__webpack_require__(182);__webpack_require__(110);__webpack_require__(183);__webpack_require__(184);__webpack_require__(185);__webpack_require__(186);__webpack_require__(187);__webpack_require__(188);__webpack_require__(189);__webpack_require__(190);__webpack_require__(191);__webpack_require__(192);__webpack_require__(193);__webpack_require__(194);__webpack_require__(195);__webpack_require__(196);__webpack_require__(197);__webpack_require__(198);__webpack_require__(199);__webpack_require__(200);__webpack_require__(201);__webpack_require__(202);__webpack_require__(203);__webpack_require__(204);__webpack_require__(205);__webpack_require__(206);__webpack_require__(207);__webpack_require__(208);__webpack_require__(209);__webpack_require__(210);__webpack_require__(211);__webpack_require__(212);__webpack_require__(213);__webpack_require__(214);__webpack_require__(215);__webpack_require__(216);__webpack_require__(217);__webpack_require__(218);__webpack_require__(219);__webpack_require__(220);var _i18n=__webpack_require__(18);var _kibanaCore__=__webpack_require__(221);var injectedMetadata=JSON.parse(document.querySelector("kbn-injected-metadata").getAttribute("data"));_i18n.i18n.init(injectedMetadata.legacyMetadata.translations);new _kibanaCore__.CoreSystem({injectedMetadata:injectedMetadata,rootDomElement:document.body,requireLegacyFiles:function requireLegacyFiles(){__webpack_require__(4710)}}).start()},4710:function(module,exports,__webpack_require__){"use strict";__webpack_require__(364);var _chrome=__webpack_require__(9);var _chrome2=_interopRequireDefault(_chrome);var _state_hashing=__webpack_require__(417);var _routes=__webpack_require__(13);var _routes2=_interopRequireDefault(_routes);function _interopRequireDefault(obj){return obj&&obj.__esModule?obj:{default:obj}}_routes2.default.enable();_routes2.default.when("/",{resolve:{url:function url(AppState,globalState,$window){var redirectUrl=_chrome2.default.getInjected("redirectUrl");var hashedUrl=(0,_state_hashing.hashUrl)([new AppState,globalState],redirectUrl);var url=_chrome2.default.addBasePath(hashedUrl);$window.location=url}}})}},[4709]);