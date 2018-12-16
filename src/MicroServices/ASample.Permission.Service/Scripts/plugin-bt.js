//---------------------Ajax的grid---------------------------//
/*
selector:选择器
columns:列配置
url:Ajax地址
queryParams:查询参数
*/
function AjaxGrid(selector, columns, url, queryParams, options) {
    //初始化以后的grid
    this.Grid = null;

    //容器
    this.Selector = selector;
    //列配置
    this.Columns = columns;

    this.IsCheckbox = true,

    //单选
    this.SingleSelect = true;

    //主键
    this.IdField = 'id';

    //ajax地址
    this.Url = url;

    this.SidePagination = 'server';

    this.Method = 'post';

    //调控每行的样式
    this.RowStyler = null;

    //自定义加载器
    this.Ajax = null;

    //高度
    this.Height = null;

    //是否分页
    this.Pagination = true,

    //事件配置
    this.EventConfig = {};

    //参数
    this.QueryParams = queryParams;
    //是否显示列脚
    this.ShowFooter = false;
    //是否显示列头部
    this.ShowHeader = true;
    //是否显示导出
    this.ShowExport = false;
    //导出类型（当前页，选择中行，所有页）
    this.ExportDataType = '';
    //子视图
    this.DetailView = false;

    var defaulfOptions = {};
    options = $.extend(defaulfOptions, options || {});
    //---------------私有方法--------------------
    var privateMethod = {
        //查询参数方法
        queryParamFn: function (param) {
            var oThis = this;
            $.extend(param, oThis.QueryParams);
            return param;
        },

        //加载失败
        loadError: function (status, res) {
            try {
                var data = eval('(' + res.responseText + ')');
                if (data.message) {
                    $.msgError(data.message);
                } else {
                    $.msgError('数据加载失败！');
                }
            } catch (e) {
                $.msgError('数据加载失败！');
            }
        },

        //加载成功
        loadSuccess: function (data) {
            if (options.loadSuccessCallBack) {
                options.loadSuccessCallBack();
            }
        }
    };

    //确定好配置，初始化
    this.init = function () {
        var oThis = this;

        if (oThis.IsCheckbox) {
            columns.splice(0, 0, { checkbox: true });
        }

        var config = {
            idField: oThis.IdField,
            uniqueId: oThis.IdField,
            striped: true,
            clickToSelect: true,
            columns: oThis.Columns,
            url: oThis.Url,
            pagination: oThis.Pagination,
            method: oThis.Method,
            singleSelect: oThis.SingleSelect,
            sidePagination: oThis.SidePagination,
            pageList: [],
            queryParamsType: '',
            undefinedText: '',
            showFooter: oThis.ShowFooter,
            showHeader: oThis.ShowHeader,
            showExport: oThis.ShowExport,
            exportDataType: oThis.ExportDataType,
            detailView: oThis.DetailView
        };
        
        //bugfix 2017.2.14 柴自强
        //不应该在内部直接初始化事件配置
        // 应该在包容外部入参的情况下兼容的附加事件配置
        if (oThis.EventConfig) {
            oThis.EventConfig["onLoadSuccess"] = privateMethod.loadSuccess;
            oThis.EventConfig["onLoadError"] = privateMethod.loadError;
        } else {
            oThis.EventConfig = {
                onLoadSuccess: privateMethod.loadSuccess,
                onLoadError: privateMethod.loadError
            };
        }
        if (oThis.Height) {
            config['height'] = oThis.Height;
        }
        //自定义加载器
        if (oThis.Ajax) {
            config['ajax'] = oThis.Ajax;
        }

        if (oThis.RowStyler) {
            config['rowStyler'] = oThis.RowStyler;
        }
        config['queryParams'] = function (param) {
            var newParam = privateMethod.queryParamFn.call(oThis, param);
            return newParam;
        };

        //事件配置
        if (oThis.EventConfig) {
            for (var eventName in oThis.EventConfig) {
                if (oThis.EventConfig.hasOwnProperty(eventName)) {
                    config[eventName] = oThis.EventConfig[eventName];
                }
            }
        }
        //加载失败
        config['onLoadError'] = function (status, res) {
            //身份失效
            var headerJson = res.getResponseHeader("X-Responded-JSON");
            if (headerJson) {
                var headerJsonObj = eval('(' + headerJson + ')');
                if (headerJsonObj.status === 401) {
                    window.location.reload();
                    return false;
                }
            }
            privateMethod.loadError(status, res);
            if (oThis.EventConfig && oThis.EventConfig['onLoadError']) {
                oThis.EventConfig['onLoadError'](status, res);
            }
        }
        //加载成功
        config['onLoadSuccess'] = function (data) {
            if (oThis.EventConfig && oThis.EventConfig['onLoadSuccess']) {
                oThis.EventConfig['onLoadSuccess'](data);
            }
        }

        oThis.Grid = $(oThis.Selector).bootstrapTable(config);
    };

    //重新加载(当前页)
    this.reload = function (queryParams) {
        var oThis = this;
        if (queryParams) {
            oThis.QueryParams = queryParams;
        }
        $(oThis.Selector).bootstrapTable('refresh');
    };

    //重新加载（回到第一页）
    this.load = function (queryParams) {
        var oThis = this;
        if (queryParams) {
            oThis.QueryParams = queryParams;
        }
        $(oThis.Selector).bootstrapTable('selectPage', 1);
    };


    //获取选中项
    this.getSelections = function (isSingle) {
        var oThis = this;
        var rows = $(oThis.Selector).bootstrapTable('getSelections');
        if (isSingle) {
            if (!rows || rows.length === 0) {
                $.msgWarn('请选择要操作的数据！');
            }
            if (rows.length > 1) {
                $.msgWarn('只能选择一条数据操作！');
            }
        }
        return rows;
    };


    //加载本地数据
    this.loadData = function (data) {
        var oThis = this;
        $(oThis.Selector).bootstrapTable('load', data);
    };

    //选中
    this.selectRows = function (ids) {
        var oThis = this;
        $(oThis.Selector).bootstrapTable('checkBy', { field: "id", values: ids });
    };

    //取消选中全部
    this.selectAll = function () {
        var oThis = this;
        $(oThis.Selector).bootstrapTable('checkAll');
    };

    //全部不选中
    this.unselectAll = function () {
        var oThis = this;
        $(oThis.Selector).bootstrapTable('uncheckAll');
    };

    //显示列
    this.showColumns = function (columns) {
        var oThis = this;
        $.each(columns, function (index, item) {
            $(oThis.Selector).bootstrapTable('showColumn', item);
        });
    };
    //隐藏列
    this.hideColumns = function (columns) {
        var oThis = this;
        $.each(columns, function (index, item) {
            $(oThis.Selector).bootstrapTable('hideColumn', item);
        });
    },
    //获取所有数据
    this.getData = function () {
        var oThis = this;
        return $(oThis.Selector).bootstrapTable('getData');
    };
};

/*
下拉列表
selector:选择器

*/
function Select(selector) {
    //容器
    this.Selector = selector;
    //是否支持搜索，默认不支持
    this.LiveSearch = false;
    //最多可以选择多少项，如果需要控制最多选择多少项，填写整数
    this.MaxOptions = false;
    //支持string | array | function  详见帮助文档
    this.MaxOptionsText = null;
    //多选项之间间隔符
    this.MultipleSeparator = ',';
    //显示
    this.ShowTick = false;
    //下拉尺寸，int:代表显示几项，false:显示所有项
    this.Size = 'auto';
    //为空时显示的提示
    this.Title = '请选择';

    //初始化
    this.init = function () {
        var oThis = this;
        var config = {
            liveSearch: oThis.LiveSearch,
            maxOptions: oThis.MaxOptions,
            multipleSeparator: oThis.MultipleSeparator,
            showTick: oThis.ShowTick,
            size: oThis.Size,
            title: oThis.Title
        };
        if (oThis.MaxOptionsText) {
            config['maxOptionsText'] = oThis.MaxOptionsText;
        }
        $(oThis.Selector).selectpicker(config);
    };

    //设置值
    this.setValue = function (val) {
        var oThis = this;
        $(oThis.Selector).selectpicker('val', val);
    };

    //设置值(多选)
    this.setValues = function (valArray) {
        var oThis = this;
        $(oThis.Selector).selectpicker('val', valArray);
    };

    //全选
    this.selectAll = function () {
        var oThis = this;
        $(oThis.Selector).selectpicker('selectAll');
    };

    //全不选
    this.unSelectAll = function () {
        var oThis = this;
        $(oThis.Selector).selectpicker('deselectAll');
    };

    //切换显示隐藏
    this.toggle = function () {
        var oThis = this;
        $(oThis.Selector).selectpicker('toggle');
    };

    //刷新
    this.refresh = function () {
        var oThis = this;
        $(oThis.Selector).selectpicker('refresh');
    };

    //显示
    this.show = function () {
        var oThis = this;
        $(oThis.Selector).selectpicker('show');
    };

    //隐藏
    this.hide = function () {
        var oThis = this;
        $(oThis.Selector).selectpicker('hide');
    }
}

/*
时间控件
selector:选择器
isTime:是否精确到小时
*/
function DateTimePicker(selector, isTime) {
    this.Selector = selector;
    this.Format = 'YYYY-MM-DD';
    if (isTime) {
        this.Format = 'YYYY-MM-DD  HH:mm';
    };
    this.MinDate = null;

    this.MaxDate = null;
    this.Icons = {
        time: 'iconfont icon-time',
        date: 'iconfont icon-rili',
        up: 'iconfont icon-arrowup',
        down: 'iconfont icon-arrowdown',
        previous: 'iconfont icon-arrowleft',
        next: 'iconfont icon-arrowlright',
        today: 'iconfont icon-xinzeng',
        clear: 'iconfont icon-xinzeng',
        close: 'iconfont icon-xinzeng'
    };
    this.ToolbarPlacement = 'default';
    this.ShowTodayButton = false;

    //初始化
    this.init = function () {
        var oThis = this;
        var config = {
            format: oThis.Format,
            icons: oThis.Icons,
            enabledHours: oThis.EnabledHours,
            toolbarPlacement: oThis.ToolbarPlacement,
            showTodayButton: oThis.ShowTodayButton
        };
        //最小时间
        if (oThis.MinDate) {
            config['minDate'] = oThis.MinDate;
        }
        //最大时间
        if (oThis.MaxDate) {
            config['maxDate'] = oThis.MaxDate;
        }
        if (oThis.EnabledHours) {
            config['enabledHours'] = oThis.EnabledHours;
        }
        if (oThis.DisabledHours) {
            config['disabledHours'] = oThis.DisabledHours;
        }
        $(oThis.Selector).datetimepicker(config);
    };

    //获取时间
    this.getValue = function () {
        var oThis = this;
        var dateValue = $(oThis.Selector).datetimepicker('date');
        if (dateValue) {
            return moment(dateValue).format(oThis.Format);
        }
        return '';
    };

    //赋值
    this.setValue = function (val) {
        var oThis = this;
        $(oThis.Selector).datetimepicker('date', val);
    }
};

/*
树控件
selector:选择器
isTime:是否精确到小时
*/
function Tree(selector, url) {
    //选择器
    this.Selector = selector;

    this.Levels = 2;

    //远处url
    this.Url = url;

    //是否多选，默认false
    this.MultiSelect = false;

    //节点图标
    this.NodeIcon = null;

    //鼠标经过颜色 默认
    this.OnhoverColor = '#F5F5F5';

    //是否显示边框
    this.ShowBorder = true;

    //是否显示Checkbox
    this.ShowCheckbox = false;

    this.EventConfig = {};

    this.Nodes = {};

    //选中的icon
    this.CheckedIcon = 'iconfont icon-xuanzhong';
    //没选中的icon
    this.UncheckedIcon = 'iconfont icon-weixuanzhong';
    this.ExpandIcon = 'iconfont icon-plus';
    this.CollapseIcon = 'iconfont icon-minus';

    //数据
    this.Data = null;

    //---私有方法      begin---------------------------------------------
    var privateMethod = {
        //选中方法
        nodeChecked: function (event, node) {
            var oThis = this;
            var id = node['id'];
            node = oThis.Nodes[id];
            if (node['isMethod']) {
                delete node['isMethod'];
                return false;
            }
            //选中父级
            var parentNode = $(oThis.Selector).treeview('getParent', node);
            if (typeof (parentNode['nodeId']) != 'undefined') {
                if (parentNode.state['checked']) {
                    return false;
                }
                parentNode['isMethod'] = true;
                $(oThis.Selector).treeview('checkNode', parentNode);
            }
            //选中所有子集
            var checkChild = function (node) {
                var childNodes = node['nodes'];
                if (childNodes) {
                    $.each(childNodes, function (i, item) {
                        var childNode = $(oThis.Selector).treeview('getNode', item['nodeId']);
                        if (childNode.state['checked']) {
                            return false;
                        }
                        $(oThis.Selector).treeview('checkNode', childNode);
                        if (item['nodes'] && item['nodes'].length > 0) {
                            checkChild(node);
                        }
                    });
                }
            };
            checkChild(node);
            return false;
        },

        //取消选中方法
        nodeUnchecked: function (event, node) {
            var oThis = this;
            var id = node['id'];
            var currentNode = oThis.Nodes[id];
            if (currentNode['isMethodUncheck']) {
                delete currentNode['isMethodUncheck'];
                return false;
            }
            //如果兄弟节点都不选中，去掉父级选中
            var uncheckParentFn = function (node) {
                //查询兄弟节点
                var sibingNodes = $(oThis.Selector).treeview('getSiblings', node);
                var isAllUncheck = true;
                $.each(sibingNodes, function (i, node) {
                    if (node.state['checked']) {
                        isAllUncheck = false;
                    }
                });
                //去掉父级选中
                if (isAllUncheck) {
                    var parentNode = $(oThis.Selector).treeview('getParent', node);
                    if (typeof (parentNode['nodeId']) != 'undefined') {
                        $(oThis.Selector).treeview('uncheckNode', parentNode);
                    }
                }
            };
            uncheckParentFn(node);
            //所有子节点置成不选中
            if (node['nodes'] && node['nodes'].length > 0) {
                for (var i = 0; i < node['nodes'].length; i++) {
                    var item = node['nodes'][i];
                    var childNode = $(oThis.Selector).treeview('getNode', item['nodeId']);
                    if (!childNode.state['checked']) {
                        continue;
                    }
                    childNode['isMethodUncheck'] = true;
                    $(oThis.Selector).treeview('uncheckNode', childNode);
                }
            }

        },

        //初始化node
        initNodes: function (nodes) {
            var oThis = this;
            oThis.Nodes = {};
            if (nodes && nodes.length > 0) {
                for (var i = 0; i < nodes.length; i++) {
                    var currentNode = nodes[i];
                    var nodeId = currentNode['id'];
                    oThis.Nodes[nodeId] = currentNode;
                }
            }
        }
    };
    //---私有方法      end---------------------------------------------

    //初始化
    this.loadData = function (data, queryParams) {
        var oThis = this;
        var config = {
            multiSelect: oThis.MultiSelect,
            onhoverColor: oThis.OnhoverColor,
            showCheckbox: oThis.ShowCheckbox,
            checkedIcon: oThis.CheckedIcon,
            uncheckedIcon: oThis.UncheckedIcon,
            expandIcon: oThis.ExpandIcon,
            collapseIcon: oThis.CollapseIcon,
            levels: oThis.Levels
        };

        $.extend(config, oThis.EventConfig);


        //默认自带事件
        config['onNodeChecked'] = function (event, node) {
            privateMethod.nodeChecked.call(oThis, event, node);
            if (oThis.EventConfig['onNodeChecked']) {
                oThis.EventConfig['onNodeChecked'](event, node);
            }
        };
        config['onNodeUnchecked'] = function (event, node) {
            privateMethod.nodeUnchecked.call(oThis, event, node);
            if (oThis.EventConfig['onNodeUnchecked']) {
                oThis.EventConfig['onNodeUnchecked'](event, node);
            }
        };

        if (oThis.NodeIcon) {
            config['nodeIcon'] = oThis.NodeIcon;
        }

        if (data) {
            oThis.Data = data;
            config['data'] = data;
            $(oThis.Selector).treeview(config);
            //将所有节点
            var nodes = $(oThis.Selector).treeview('getAllNodes');
            privateMethod.initNodes.call(oThis, nodes);
        } else {
            var params = queryParams;
            var successFn = function (data) {
                oThis.Data = data;
                config['data'] = data;
                $(oThis.Selector).treeview(config);
                var nodes = $(oThis.Selector).treeview('getAllNodes');
                privateMethod.initNodes.call(oThis, nodes);
            };
            $.ajaxPost(oThis.Url, params, successFn);
        }

    };

    //获取checked的node
    this.getChecked = function () {
        var oThis = this;
        var checkedArray = [];
        var searchChecked = function (nodes) {
            $.each(nodes, function (i, item) {
                var id = item['id'];
                var node = oThis.Nodes[id];
                if (node && node.state['checked']) {
                    checkedArray.push(node);
                }
                if (node['nodes'] && node['nodes'].length > 1) {
                    searchChecked(node['nodes']);
                }
            });
        };
        searchChecked(oThis.Data);
        return checkedArray;
    };

    //获取select的node
    this.getSelected = function () {
        var oThis = this;
        return $(oThis.Selector).treeview('getSelected');
    };

    /**
     * 返回给定节点的父节点或者顶级会返回包含这个树的dom对象，
     * 最好判断下先parentId是不是为null。
     * @param {可以是节点对象或者ID} node 
     * @returns {返回给定节点的父节点对象或者顶级会返回包含这个树的dom对象。} 
     */
    this.getParent = function (node) {
        var oThis = this;
        return $(oThis.Selector).treeview('getParent', node);
    }

    //选中id的节点
    this.check = function (id, isNoCheckChild) {
        var oThis = this;
        var node = oThis.Nodes[id];
        if (node) {
            if (isNoCheckChild) {
                node['isMethod'] = true;
            }
            $(oThis.Selector).treeview('checkNode', node);
        }
    };

    //选中所有
    this.checkAll = function () {
        var oThis = this;
        $(oThis.Selector).treeview('checkAll');
    };

    //取消选中节点
    this.uncheck = function (id) {
        var oThis = this;
        var node = oThis.Nodes[id];
        $(oThis.Selector).treeview('uncheckNode', node);
    };

    //取消选中所有
    this.uncheckAll = function () {
        var oThis = this;
        $(oThis.Selector).treeview('uncheckAll');
    };

};

/*
文件上传控件
*/
function InputFile(selector) {
    //选择器
    this.Selector = selector;
    //是否显示预览
    this.ShowPreview = true;
    //是否显示input框
    this.ShowCaption = true;
    //是否显示清除按钮
    this.ShowRemove = true;
    //是否显示上传按钮
    this.ShowUpload = false;
    //是否显示zoom
    this.ShowZoom = true;
    //图片最小高度
    this.MinImageWidth = null;
    this.MaxImageWidth = null;
    this.MinImageHeight = null;
    this.MaxImageHeight = null;

    //允许上传的文件类型（优先）
    this.AllowedFileTypes = null;
    //允许上传的文件后缀
    this.AllowedFileExtensions = null;

    //最小文件个数
    this.MinFileCount = 1;
    //最多文件个数
    this.MaxFileCount = 1;

    //文件最小容量
    this.MinFileSize = null;
    //文件最大容量
    this.MaxFileSize = null;

    //错误信息显示
    this.ErrorSelector = null;

    //初始化
    this.init = function () {
        var oThis = this;
        var config = {
            showPreview: oThis.ShowPreview,
            showCaption: oThis.ShowCaption,
            showRemove: oThis.ShowRemove,
            showUpload: oThis.ShowUpload,
            minFileCount: oThis.MinFileCount,
            maxFileCount: oThis.MaxFileCount,
            fileActionSettings: {
                showZoom: oThis.ShowZoom
            }
        };
        if (oThis.ErrorSelector) {
            config['elErrorContainer'] = oThis.ErrorSelector;
        }
        if (oThis.AllowedFileTypes) {
            config['allowedFileTypes'] = oThis.AllowedFileTypes;
        }
        if (oThis.AllowedFileExtensions) {
            config['allowedFileExtensions'] = oThis.AllowedFileExtensions;
        }

        if (oThis.MinImageWidth) {
            config['minImageWidth'] = oThis.MinImageWidth;
        }
        if (oThis.MaxImageWidth) {
            config['maxImageWidth'] = oThis.MaxImageWidth;
        }
        if (oThis.MinImageHeight) {
            config['minImageHeight'] = oThis.MinImageHeight;
        }
        if (oThis.MaxImageHeight) {
            config['maxImageHeight'] = oThis.MaxImageHeight;
        }
        if (oThis.MinFileSize) {
            config['minFileSize'] = oThis.MinFileSize;
        }
        if (oThis.MaxFileSize) {
            config['maxFileSize'] = oThis.MaxFileSize;
        }
        $(oThis.Selector).fileinput(config);
    },
    //初始化预览图片
        this.initPreviewImg = function (images) {
            var oThis = this;
            if (images.length > 0) {
                var previewArray = [];
                for (var i = 0; i < images.length; i++) {
                    var item = images[i];
                    previewArray.push('<img src="' + item.path + '" class="file-preview-image" alt="' + item.name + '" title="' + item.name + '">');
                }
                $(oThis.Selector).fileinput('refresh', { initialPreview: previewArray });
            }
        };

    //清空
    this.clear = function () {
        var oThis = this;
        $(oThis.Selector).fileinput('clear');
    };
};


$.extend({
    //弹出成功消息
    msgSuccess: function (msg) {
        toastr.clear();
        toastr.options = {
            'closeButton': false,
            'debug': false,
            'newestOnTop': false,
            'progressBar': true,
            'positionClass': 'toast-top-right',
            'preventDuplicates': true,
            'onclick': null,
            'showDuration': '300',
            'hideDuration': '1000',
            'timeOut': '5000',
            'extendedTimeOut': '1000',
            'showEasing': 'swing',
            'hideEasing': 'linear',
            'showMethod': 'fadeIn',
            'hideMethod': 'fadeOut'
        }
        toastr.success(msg);
    },
    //警告
    msgWarn: function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr.warning(msg);
    },

    //错误
    msgError: function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr.error(msg);
    },

    //消息
    msgInfo: function (msg) {
        toastr.clear();
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr.info(msg);
    },
    //loading
    loading: function (msg) {
        if (msg) {
            layer.msg(msg, {
                icon: 16,
                time: 0,
                shade: 0.01,
                scrollbar: false
            });
        } else {
            layer.load(0, {
                scrollbar: false
            });
        }
    },

    //关闭loading
    hideLoading: function () {
        layer.closeAll('loading');
        layer.closeAll('dialog');
    },

    //询问提示框
    confirm: function (msg, callback) {
        layer.confirm(msg, { icon: 3, title: '提示', scrollbar: false }, function (index) {
            callback(true);
            layer.close(index);
        });
    }
});
