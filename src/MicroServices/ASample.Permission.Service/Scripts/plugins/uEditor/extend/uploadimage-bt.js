/**
 * UEditor控件扩展
 * 上传图片
 */
(function () {
    UE.registerUI('uploadimage', function (editor, uiname) {
        //创建一个按钮
        var imageSelectId = editor.options.imageSelectId;
        var btn = new UE.ui.Button({
            name: '添加图片',
            //鼠标移动到上面的提示信息
            title: '上传图片',
            //添加样式
            cssRules: 'background-position: -726px -77px;',
            //点击执行时的命令
            onclick:function() {
                //点击按钮的操作，一般用来执行命令
                //选择图片窗口
                eval(imageSelectId + 'Method').init(function (img) {
                    //在焦点处插入图片
                    $.each(img, function(index, item) {
                        var imgHTml = $('<img>').attr('src', item.path).prop('outerHTML');
                        editor.execCommand('inserthtml', imgHTml);
                    });
                });
            }
        });
        return btn;
    });
})();