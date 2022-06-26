export function guid(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c === 'x' ? r : ((r & 0x3) | 0x8);
        return v.toString(16);
    });
}

// // This is also nice way, however for nodejs we will need polyfill for crypto
// export function guid() {
//     return (([1e7] as any)+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, (c: number) => (((c ^ crypto.getRandomValues(new Uint8Array(1))[0]) & 15) >> c / 4).toString(16));
// }
