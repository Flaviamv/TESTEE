class request {

    static createOptions = function (method, obj = null) {
        let options = {};

        if (options.headers == null)
            options.headers = {};

        options.method = method;
        options.headers = {
            "Content-Type": "application/json"
        }
        if (obj != null){
            options.body = JSON.stringify(obj);
        }
        return options;
    }

    static get = async function (url) {
        const options = request.createOptions("GET");
        return await fetch(url, options);
    }

    static post = async function (url, obj = null) {
        const options = request.createOptions("POST", obj);
        return await fetch(url, options);
    }

    static put = async function (url, obj = null) {
        const options = request.createOptions("PUT", obj);
        return await fetch(url, options);
    }

    static patch = async function (url, obj = null) {
        const options = request.createOptions("PATCH", obj);
        return await fetch(url, options);
    }

    static delete = async function (url, obj = null) {
        const options = request.createOptions("DELETE", obj);
        return await fetch(url, options);
    }
}