/** layui-v2.5.7 MIT License */
 ;layui.define(function(e){"use strict";var t=document,a="getElementById",r="getElementsByTagName",n="laypage",i="layui-disabled",u=function(e){var t=this;t.config=e||{},t.config.index=++p.index,t.render(!0)};u.prototype.type=function(){var e=this.config;if("object"==typeof e.elem)return void 0===e.elem.length?2:3},u.prototype.view=function(){var e=this,t=e.config,a=t.groups="groups"in t?0|t.groups:5;t.layout="object"==typeof t.layout?t.layout:["prev","page","next"],t.count=0|t.count,t.curr=0|t.curr||1,t.limits="object"==typeof t.limits?t.limits:[10,20,30,40,50],t.limit=0|t.limit||10,t.pages=Math.ceil(t.count/t.limit)||1,t.curr>t.pages&&(t.curr=t.pages),a<0?a=1:a>t.pages&&(a=t.pages),t.prev="prev"in t?t.prev:"&#x4E0A;&#x4E00;&#x9875;",t.next="next"in t?t.next:"&#x4E0B;&#x4E00;&#x9875;",t.rpptext="rpptext"in t?t.rpptext:"条/页",t.totaltext="totaltext"in t?t.totaltext:"共",t.recordtext="recordtext"in t?t.recordtext:"条",t.gototext="gototext"in t?t.gototext:"&#x5230;&#x7B2C;",t.pagetext="pagetext"in t?t.pagetext:"页",t.oktext="oktext"in t?t.oktext:"&#x786e;&#x5b9a;";var r=t.pages>a?Math.ceil((t.curr+(a>1?1:0))/(a>0?a:1)):1,n={prev:function(){return t.prev?'<a href="javascript:;" class="layui-laypage-prev'+(1==t.curr?" "+i:"")+'" data-page="'+(t.curr-1)+'">'+t.prev+"</a>":""}(),page:function(){var e=[];if(t.count<1)return"";r>1&&t.first!==!1&&0!==a&&e.push('<a href="javascript:;" class="layui-laypage-first" data-page="1"  title="&#x9996;&#x9875;">'+(t.first||1)+"</a>");var n=Math.floor((a-1)/2),i=r>1?t.curr-n:1,u=r>1?function(){var e=t.curr+(a-n-1);return e>t.pages?t.pages:e}():a;for(u-i<a-1&&(i=u-a+1),t.first!==!1&&i>2&&e.push('<span class="layui-laypage-spr">&#x2026;</span>');i<=u;i++)i===t.curr?e.push('<span class="layui-laypage-curr"><em class="layui-laypage-em" '+(/^#/.test(t.theme)?'style="background-color:'+t.theme+';"':"")+"></em><em>"+i+"</em></span>"):e.push('<a href="javascript:;" data-page="'+i+'">'+i+"</a>");return t.pages>a&&t.pages>u&&t.last!==!1&&(u+1<t.pages&&e.push('<span class="layui-laypage-spr">&#x2026;</span>'),0!==a&&e.push('<a href="javascript:;" class="layui-laypage-last" title="&#x5C3E;&#x9875;"  data-page="'+t.pages+'">'+(t.last||t.pages)+"</a>")),e.join("")}(),next:function(){return t.next?'<a href="javascript:;" class="layui-laypage-next'+(t.curr==t.pages?" "+i:"")+'" data-page="'+(t.curr+1)+'">'+t.next+"</a>":""}(),count:'<span class="layui-laypage-count">'+t.totaltext+" "+t.count+" "+t.recordtext+"</span>",limit:function(){var e=['<span class="layui-laypage-limits"><select lay-ignore>'];return layui.each(t.limits,function(a,r){e.push('<option value="'+r+'"'+(r===t.limit?"selected":"")+">"+r+" "+t.rpptext+"</option>")}),e.join("")+"</select></span>"}(),refresh:['<a href="javascript:;" data-page="'+t.curr+'" class="layui-laypage-refresh">','<i class="layui-icon layui-icon-refresh"></i>',"</a>"].join(""),skip:function(){return['<span class="layui-laypage-skip">'+t.gototext,'<input type="text" min="1" value="'+t.curr+'" class="layui-input">',t.pagetext+'<button type="button" class="layui-laypage-btn">'+t.oktext+"</button>","</span>"].join("")}()};return['<div class="layui-box layui-laypage layui-laypage-'+(t.theme?/^#/.test(t.theme)?"molv":t.theme:"default")+'" id="layui-laypage-'+t.index+'">',function(){var e=[];return layui.each(t.layout,function(t,a){n[a]&&e.push(n[a])}),e.join("")}(),"</div>"].join("")},u.prototype.jump=function(e,t){if(e){var a=this,n=a.config,i=e.children,u=e[r]("button")[0],l=e[r]("input")[0],s=e[r]("select")[0],o=function(){var e=0|l.value.replace(/\s|\D/g,"");e&&(n.curr=e,a.render())};if(t)return o();for(var c=0,g=i.length;c<g;c++)"a"===i[c].nodeName.toLowerCase()&&p.on(i[c],"click",function(){var e=0|this.getAttribute("data-page");e<1||e>n.pages||(n.curr=e,a.render())});s&&p.on(s,"change",function(){var e=this.value;n.curr*e>n.count&&(n.curr=Math.ceil(n.count/e)),n.limit=e,a.render()}),u&&p.on(u,"click",function(){o()})}},u.prototype.skip=function(e){if(e){var t=this,a=e[r]("input")[0];a&&p.on(a,"keyup",function(a){var r=this.value,n=a.keyCode;/^(37|38|39|40)$/.test(n)||(/\D/.test(r)&&(this.value=r.replace(/\D/,"")),13===n&&t.jump(e,!0))})}},u.prototype.render=function(e){var r=this,n=r.config,i=r.type(),u=r.view();2===i?n.elem&&(n.elem.innerHTML=u):3===i?n.elem.html(u):t[a](n.elem)&&(t[a](n.elem).innerHTML=u),n.jump&&n.jump(n,e);var p=t[a]("layui-laypage-"+n.index);r.jump(p),n.hash&&!e&&(location.hash="!"+n.hash+"="+n.curr),r.skip(p)};var p={render:function(e){var t=new u(e);return t.index},index:layui.laypage?layui.laypage.index+1e4:0,on:function(e,t,a){return e.attachEvent?e.attachEvent("on"+t,function(t){t.target=t.srcElement,a.call(e,t)}):e.addEventListener(t,a,!1),this}};e(n,p)});