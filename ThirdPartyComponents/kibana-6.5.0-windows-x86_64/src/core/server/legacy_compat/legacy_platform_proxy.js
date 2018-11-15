"use strict";
/*
 * Licensed to Elasticsearch B.V. under one or more contributor
 * license agreements. See the NOTICE file distributed with
 * this work for additional information regarding copyright
 * ownership. Elasticsearch B.V. licenses this file to you under
 * the Apache License, Version 2.0 (the "License"); you may
 * not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
Object.defineProperty(exports, "__esModule", { value: true });
const events_1 = require("events");
/**
 * List of the server events to be forwarded to the legacy platform.
 */
const ServerEventsToForward = [
    'clientError',
    'close',
    'connection',
    'error',
    'listening',
    'upgrade',
];
/**
 * Represents "proxy" between legacy and current platform.
 * @internal
 */
class LegacyPlatformProxy extends events_1.EventEmitter {
    constructor(log, server) {
        super();
        this.log = log;
        this.server = server;
        // HapiJS expects that the following events will be generated by `listener`, see:
        // https://github.com/hapijs/hapi/blob/v14.2.0/lib/connection.js.
        this.eventHandlers = new Map(ServerEventsToForward.map(eventName => {
            return [
                eventName,
                (...args) => {
                    this.log.debug(`Event is being forwarded: ${eventName}`);
                    this.emit(eventName, ...args);
                },
            ];
        }));
        for (const [eventName, eventHandler] of this.eventHandlers) {
            this.server.addListener(eventName, eventHandler);
        }
    }
    /**
     * Neither new nor legacy platform should use this method directly.
     */
    address() {
        this.log.debug('"address" has been called.');
        return this.server.address();
    }
    /**
     * Neither new nor legacy platform should use this method directly.
     */
    listen(port, host, callback) {
        this.log.debug(`"listen" has been called (${host}:${port}).`);
        if (callback !== undefined) {
            callback();
        }
    }
    /**
     * Neither new nor legacy platform should use this method directly.
     */
    close(callback) {
        this.log.debug('"close" has been called.');
        if (callback !== undefined) {
            callback();
        }
    }
    /**
     * Neither new nor legacy platform should use this method directly.
     */
    getConnections(callback) {
        this.log.debug('"getConnections" has been called.');
        // This method is used by `even-better` (before we start platform).
        // It seems that the latest version of parent `good` doesn't use this anymore.
        this.server.getConnections(callback);
    }
}
exports.LegacyPlatformProxy = LegacyPlatformProxy;
