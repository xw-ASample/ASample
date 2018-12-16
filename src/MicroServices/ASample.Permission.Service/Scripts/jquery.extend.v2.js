/*基础功能库*/
$.extend({

    jsonToUrl: function (object) {
        var url = '';
        for (var field in object) {
            url += field + '=' + (object[field] == null ? "" : object[field]) + '&';
        }
        return url.substring(0, url.length - 1);
    },

    //json数据转化为url
    combineUrl: function (url, data) {
        if (data) {
            var combineUrl;
            if (url.indexOf('?') > 0) {
                combineUrl = url;
                if (combineUrl.substring(combineUrl.length - 1, combineUrl.length) != '&') {
                    combineUrl += '&';
                }
            } else {
                combineUrl = url + '?';
            }
            var queryString = $.jsonToUrl(data);
            combineUrl += queryString;
            return combineUrl;
        }
        return url;
    },

    //绑定toolbar事件
    bindToolEvent: function (btns, methodO) {
        btns.each(function (i) {
            var currentBtn = $(btns[i]);
            var id = currentBtn.attr('id');
            if (id) {
                var fnName = id.replace('btn', '');
                var firstLetter = fnName.substr(0, 1).toLowerCase();
                fnName = firstLetter + fnName.substring(1);
                if (methodO && methodO.hasOwnProperty(fnName)) {
                    currentBtn.click(methodO[fnName]);
                }
            }
        });
    },

    //打包Form或者查询的data
    packData: function (selector) {
        var elements = $(selector + " [name]");
        var data = {};
        for (var i = 0; i < elements.length; i++) {
            var el = $(elements[i]);
            var name = el.attr('name');
            var value = el.val();
            if (typeof (value) === 'string') {
                value = $.trim(el.val());
            }
            //select多选的数组
            if ($.isArray(value)) {
                value = value.join(',');
            }
            if (el.is('input') && el.attr('type') === 'checkbox') {
                if (el.is(':checked')) {
                    if (data[name]) {
                        data[name] += ',' + value;
                    } else {
                        data[name] = value;
                    }
                }
                continue;
            }
            data[name] = value;
        }
        return data;
    },

    //清空Form
    clearForm: function (canvas) {
        canvas.find('input').each(function (i, item) {
            if ($(item).attr('type') === 'checkbox') {
                var id = $(item).attr('id');
                if (id) {
                    $('#' + id).iCheck('uncheck');
                }
                $(item).prop('checked', false);
            } else {
                $(item).val('');
            }
        });
        canvas.find('textarea').val('');
    },
    //货币格式为千位分割
    moneyFormat: function (s) {
        if (/[^0-9\.]/.test(s)) return "invalid value";
        s = s.replace(/^(\d*)$/, "$1.");
        s = (s + "00").replace(/(\d*\.\d\d)\d*/, "$1");
        s = s.replace(".", ",");
        var re = /(\d)(\d{3},)/;
        while (re.test(s))
            s = s.replace(re, "$1,$2");
        s = s.replace(/,(\d\d)$/, ".$1");
        return s.replace(/^\./, "0.");
    }
});

$.extend({
    //包装后的Ajax
    //RESTful httpType: get、post、put、delete
    ajaxReq: function (url, params, successFn, msg, useJson, httpType) {
        url = url || "", params = params || {}, successFn = successFn || function () { };
        msg = msg ? msg : '请稍后...';

        //params对象转换为querystring
        if (httpType === "get")
        {
            var arr = new Array();
            for(var p in params)
            {
                arr.push(p + "=" + params[p]);
            }

            var queryStr = arr.join("&");
            url = url.indexOf("?") < 0 ? url + "?" + queryStr : url + "&" + queryStr;
            params = null;
        }

        //$.loading(msg);
        var option = {
            url: url,
            type: httpType,
            data: params,
            dataType :  "json",
            complete: function (xhr, ts) {
                xhr = null;
                return;
            },
            statusCode: {
                //成功
                200: function (result, textStatus, jqXhr) {
                    if (result.needRedirect) {
                        return this.statusCode[302](result);
                    }
                    $.hideLoading();
                    successFn(result);
                    return false;
                },
                //警告。服务器已接受请求，但尚未处理
                202: function (result) {
                    $.hideLoading();
                    var data = result.responseJSON;
                    if (data.needRedirect) {
                        window.location.href = data.redirectUrl;
                        return;
                    }
                    successFn();
                    return;
                },

                //成功，但不需要返回任何内容
                204: function () {
                    $.hideLoading();
                    successFn();
                    return;
                },

                303: function (result) {
                    //var data = eval('(' + result.responseText + ')');
                    //window.location.href = data.RedirectUrl;
                },
                302: function (data) {
                    $.hideLoading();
                    if(successFn() == false)
                        return;
                    $.msgSuccess(data.message ? data.message : '跳转中...');
                    window.location.href = data.redirectUrl;
                },
                //错误
                400: function (result) {
                    $.hideLoading();
                    var data = result.responseJSON;
                    if (data.needRedirect) {
                        $.msgSuccess(data.message ? data.message : '跳转中...');
                        setTimeout(function () {
                            window.location.href = data.redirectUrl;
                        }, 100);
                        return;
                    }
                    $.msgError(data.message);
                    return;
                },
                //警告
                500: function (result) {
                    $.hideLoading();
                    var data = eval('(' + result.responseText + ')');
                    $.msgWarn(data.message);
                    //layer.msg(result.responseJSON.message, { closeBtn: 1, time: 10000, });
                    return;
                },
                //未实现
                501: function (result) {
                    var data = eval('(' + result.responseText + ')');
                    $.msgError(data.message);
                    return;
                },
                //未登录
                401: function (result) {
                    var url = result['redirectUrl'];
                    if (url) {
                        location.href = url;
                    } else {
                        window.location.reload();
                    }
                    return;
                },
                //成功，但没有任何数据返回
                404: function (result) {
                    $.hideLoading();                 
                    layer.msg(result.responseJSON.message, { closeBtn: 1,time: 10000,});
                    successFn(result);
                    return false;
                }
            }
        };
        if (useJson) {
            option.contentType = "application/json";
            option.data = JSON.stringify(params);
        }
        return $.ajax(option);
    },

    getReq: function(url, params, successFn, msg, useJson)
    {
        this.ajaxReq(url, params, successFn, msg, useJson, "get");
    },

    postReq: function(url, params, successFn, msg, useJson)
    {
        this.ajaxReq(url, params, successFn, msg, useJson, "post");
    },

    putReq: function(url, params, successFn, msg, useJson)
    {
        $.ajaxReq(url, params, successFn, msg, useJson, "put");
    },

    deleteReq: function(url, params, successFn, msg, useJson)
    {
        $.ajaxReq(url, params, successFn, msg, useJson, "delete");
    },

    //不拼接为QueryString
    ajaxReqNew: function (url, params, successFn, msg, useJson, httpType) {
        url = url || "", params = params || {}, successFn = successFn || function () { };
        msg = msg ? msg : '请稍后...';

        //$.loading(msg);
        var option = {
            url: url,
            type: httpType,
            data: params,
            dataType: "json",
            complete: function (xhr, ts) {
                xhr = null;
                return;
            },
            statusCode: {
                //成功
                200: function (result, textStatus, jqXhr) {
                    if (result.needRedirect) {
                        return this.statusCode[302](result);
                    }
                    $.hideLoading();
                    successFn(result);
                    return false;
                },
                //警告。服务器已接受请求，但尚未处理
                202: function (result) {
                    $.hideLoading();
                    var data = result.responseJSON;
                    if (data.needRedirect) {
                        window.location.href = data.redirectUrl;
                        return;
                    }
                    successFn();
                    return;
                },

                //成功，但不需要返回任何内容
                204: function () {
                    $.hideLoading();
                    successFn();
                    return;
                },
                303: function (result) {
                    //var data = eval('(' + result.responseText + ')');
                    //window.location.href = data.RedirectUrl;
                },
                302: function (data) {
                    $.hideLoading();
                    if (successFn() == false)
                        return;
                    $.msgSuccess(data.message ? data.message : '跳转中...');
                    window.location.href = data.redirectUrl;
                },
                //错误
                400: function (data) {
                    $.hideLoading
                    if (data.needRedirect) {
                        $.msgSuccess(data.message ? data.message : '跳转中...');
                        setTimeout(function () {
                            window.location.href = data.redirectUrl;
                        }, 100);
                        return;
                    }
                    $.msgError(data.message);
                    return;
                },
                //警告
                500: function (result) {
                    $.hideLoading();
                    var data = eval('(' + result.responseText + ')');
                    $.msgWarn(data.message);
                    //layer.msg(result.responseJSON.message, { closeBtn: 1, time: 10000, });
                    return;
                },
                //未实现
                501: function (result) {
                    var data = eval('(' + result.responseText + ')');
                    $.msgError(data.message);
                    return;
                },
                //未登录
                401: function (result) {
                    var url = result['redirectUrl'];
                    if (url) {
                        location.href = url;
                    } else {
                        window.location.reload();
                    }
                    return;
                },
                //成功，但没有任何数据返回
                404: function (result) {
                    $.hideLoading();
                    //$.msgWarn(result.responseJSON.message);
                    layer.msg(result.responseJSON.message, { closeBtn: 1, time: 10000, });
                    successFn(result);
                    return false;
                }
            }
        };
        if (useJson) {
            option.contentType = "application/json";
            option.data = JSON.stringify(params);
        }
        return $.ajax(option);
    },

    getReqNew: function (url, params, successFn, msg, useJson) {
        this.ajaxReqNew(url, params, successFn, msg, useJson, "get");
    },


    //远程验证
    remoteValidate: function (url, param) {
        var failMsg = false;
        $.ajax({
            url: url,
            type: 'post',
            async: false,
            data: param,
            complete: function (xhr, ts) {
                xhr = null;
                return;
            },
            error: function (result) {
                var data = eval('(' + result.responseText + ')');
                if (data && data.message) {
                    failMsg = data.message;
                } else {
                    failMsg = '验证失败！';
                }
            }
        });
        return failMsg;
    },

    //自动复制form(通过name)
    loadForm: function (selector, data) {
        $.each(data, function (key, item) {
            if (item != null && typeof (item) === 'object') {
                $.loadForm(selector, item);
            }
            var control = $(selector + ' [name="' + key + '"]');
            if (control.length === 0) {
                return true;
            }
            //checkbox控件
            if (control.attr('type') === 'checkbox') {
                var id = control.attr('id');
                if (id) {
                    if (item === true) {
                        $('#' + id).iCheck('check');
                    } else {
                        $('#' + id).iCheck('uncheck');
                    }
                }
                control.prop('checked', item);
                return true;
            }
            //图片
            if (control[0].localName === "img") {
                control.attr('src', item);
                return true;
            }
            control.val(item);
            //下拉框执行会有bug,有些数据是绑定到对象的，并非由dom元素，所以用length来区分
            if (control[0].localName !== "select" && control[0].localName !== 'div' && control[0].localName !== 'img') {
                control.html(item);
            }
        });
    }
});

//打开窗体
$.fn.openForm = function (titile) {
    var content = $(this);
    //宽度
    var formWidth = $(window).width() * 0.6;
    formWidth = formWidth < 500 ? 500 : formWidth;
    formWidth = formWidth > 900 ? 900 : formWidth;
    var index = layer.open({
        type: 1,
        title: titile,
        scrollbar: false,
        area: formWidth + 'px',
        maxWidth: 900,
        content: content
    });
    return index;
};


$.extend({
    //打开看到图片详情
    openImageForm:function(src) {
        //宽度
        var formWidth = $(window).width() * 0.6;
        formWidth = formWidth < 500 ? 500 : formWidth;
        formWidth = formWidth > 900 ? 900 : formWidth;
        var  formHeight = $(window).height() -200;
        var content = '<div style="max-height:' + formHeight + 'px;"><img src="' + src + '" style="height:auto;display: block;margin-left:auto;margin-right:auto;"/></div>';
        layer.open({
            type: 1,
            title: '图片详情',
            scrollbar: false,
            area: formWidth + 'px',
            maxWidth: 900,
            offset: '130px',
            content: content
        });
    }
});

//关闭窗体
$.fn.closeForm = function (index) {
    if (index) {
        layer.close(index);
    }
    else {
        layer.closeAll('page');
    }
};
//--------------------图片自适应   start---------------------------
$.fn.imageAdaption = function () {
    $(this).each(function () {
        var frame = $(this);
        var img = frame.children('img');
        img.hide();
        var imgtemp = $(new Image());
        imgtemp.load(function () {
            var imgW = this.width;
            var imgH = this.height;
            var frameW = frame.width();
            var frameH = frame.height();
            var wScale = imgW / frameW;
            var hScale = imgH / frameH;
            var scale = wScale > hScale ? hScale : wScale;
            imgW = imgW / scale;
            imgH = imgH / scale;
            img.width(imgW);
            img.height(imgH);
            if (wScale > hScale) {
                var difW = (imgW - frameW) / 2;
                difW = (difW > 0) ? difW : 0;
                img.css('marginLeft', -difW);
            } else {
                var difT = (imgH - frameH) / 2;
                difT = (difT > 0) ? difT : 0;
                img.css('marginTop', -difT);
            }
            img.show();
        });
        imgtemp.error(function () {
            if (img.attr('noerror') == '1') {
                return true;
            }
            img.show();
        });
        imgtemp.attr('src', img.attr("src"));
    });
};
//--------------------图片自适应   end---------------------------





