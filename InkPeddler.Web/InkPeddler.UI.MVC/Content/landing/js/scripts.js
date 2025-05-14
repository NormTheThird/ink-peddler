!(function (NioApp, $) {
    "use strict";
    NioApp.Package.name = "DashLite";
    NioApp.Package.version = "2.3";

    var $win = $(window), $body = $('body'), $doc = $(document), 

    //class names
    _body_theme  = 'nio-theme',
    _menu        = 'header-menu',
    _has_fixed   = 'has-fixed',
    _menu_toggle = 'menu-toggler',
    _menu_active = 'active',
    _mobile_menu = 'mobile-menu',
    _header      = 'header-main',
    //breakpoints
    _break       = NioApp.Break;
    
    function extend(obj, ext) {
        Object.keys(ext).forEach(function(key) { obj[key] = ext[key]; });
        return obj;
    }
    // ClassInit @v1.0
    NioApp.ClassNavMenu = function() {
        NioApp.BreakClass('.'+_menu, _break.lg, { timeOut: 0 } );
        $win.on('resize', function() {
            NioApp.BreakClass('.'+_menu, _break.lg);
        });
    };

    // CurrentLink Detect @v1.0
    NioApp.CurrentLink = function(){
        var _link = '.nk-menu-link, .menu-link, .nav-link',
            _currentURL = window.location.href,
            fileName = _currentURL.substring(0, (_currentURL.indexOf("#") == -1) ? _currentURL.length : _currentURL.indexOf("#")), 
            fileName = fileName.substring(0, (fileName.indexOf("?") == -1) ? fileName.length : fileName.indexOf("?"));

        $(_link).each(function() {
            var self = $(this), _self_link = self.attr('href');
            if (fileName.match(_self_link)) {
                self.closest("li").addClass('active current-page').parents().closest("li").addClass("active current-page");
                self.closest("li").children('.nk-menu-sub').css('display','block');
                self.parents().closest("li").children('.nk-menu-sub').css('display','block');
            } else {
                self.closest("li").removeClass('active current-page').parents().closest("li:not(.current-page)").removeClass("active");
            }
        });
    };


    // Toggle Screen @v1.0
    NioApp.TGL.screen = function (elm){
        if($(elm).exists()) {        
            $(elm).each(function(){
                var ssize = $(this).data('toggle-screen');
                if(ssize){ $(this).addClass('toggle-screen-' + ssize ); }
            });
        }
    };

    // Toggle Content @v1.0
    NioApp.TGL.content = function (elm, opt){
        var toggle = (elm) ? elm : '.toggle', $toggle = $(toggle), $contentD = $('[data-content]'), 
            toggleBreak = true, toggleCurrent = false, def = { active: 'active', content: 'content-active', break: toggleBreak}, attr = (opt) ? extend(def, opt) : def;

        NioApp.TGL.screen($contentD);

        $toggle.on('click', function(e){
            toggleCurrent = this;
            NioApp.Toggle.trigger($(this).data('target'), attr);
            e.preventDefault();
        });

        $doc.on('mouseup', function(e){
            if (toggleCurrent) {
                var $toggleCurrent = $(toggleCurrent), $s2c = $('.select2-container'), $dpd = $('.datepicker-dropdown'), $tpc = $('.ui-timepicker-container');
                if (!$toggleCurrent.is(e.target) && $toggleCurrent.has(e.target).length===0 && !$contentD.is(e.target) && $contentD.has(e.target).length===0
                    && !$s2c.is(e.target) && $s2c.has(e.target).length===0 && !$dpd.is(e.target) && $dpd.has(e.target).length===0
                    && !$tpc.is(e.target) && $tpc.has(e.target).length===0) {
                    NioApp.Toggle.removed($toggleCurrent.data('target'), attr);
                    toggleCurrent = false;
                }
            }
        });

        $win.on('resize', function(){
            $contentD.each(function(){
                var content = $(this).data('content'), ssize = $(this).data('toggle-screen'), toggleBreak = _break[ssize];
                if(NioApp.Win.width > toggleBreak){ 
                    NioApp.Toggle.removed(content, attr);
                } 
            });
        });
    };

    // ToggleExpand @v1.0
    NioApp.TGL.expand = function(elm, opt){
        var toggle = (elm) ? elm : '.expand', def = {toggle: true}, attr = (opt) ? extend(def, opt) : def;

        $(toggle).on('click', function(e){
            NioApp.Toggle.trigger($(this).data('target'), attr);
            e.preventDefault();
        });
    };

    // Dropdown Menu @v1.0
    NioApp.TGL.ddmenu = function(elm, opt){
        var imenu = (elm) ? elm : '.menu-toggle',
            def = { active: 'active', self: 'menu-toggle', child: 'menu-sub'},
            attr = (opt) ? extend(def, opt) : def;

        $(imenu).on('click', function(e){
            if (NioApp.Win.width < _break.lg) {
                NioApp.Toggle.dropMenu($(this), attr);
            }
            e.preventDefault();
        });
    };

    // Show Menu @v1.0
    NioApp.TGL.showmenu = function(elm, opt){
        var toggle = (elm) ? elm : '.menu-toggler', $toggle = $(toggle), $contentD = $('[data-content]'),
            toggleBreak = _break.lg,
            toggleOlay = 'header-overlay', toggleClose = {profile: true, menu: false}, 
            def = { active: 'active', content: 'active', body: 'nav-shown', overlay: toggleOlay, break: toggleBreak, close: toggleClose }, 
            attr = (opt) ? extend(def, opt) : def;

        $toggle.on('click', function(e){
            NioApp.Toggle.trigger($(this).data('target'), attr);
            e.preventDefault();
        });

        $doc.on('mouseup', function(e){
            if (!$toggle.is(e.target) && $toggle.has(e.target).length===0 && !$contentD.is(e.target) && $contentD.has(e.target).length===0 && NioApp.Win.width < toggleBreak) {
                NioApp.Toggle.removed($toggle.data('target'), attr);
            }
        });

        $win.on('resize', function(){
            if(NioApp.Win.width < _break.xl || NioApp.Win.width < toggleBreak ){ 
                NioApp.Toggle.removed($toggle.data('target'), attr);
            } 
        });
    };

    // HeaderSticky !Util @v1.0
	NioApp.headerSticky = function () {
		var $is_sticky = $('.is-sticky');
        if ($is_sticky.exists() ) {
            var navm = $is_sticky.offset();
            $win.on('scroll', function(){
                var _top = $win.scrollTop();
                if(_top > navm.top){
                    if(!$is_sticky.hasClass(_has_fixed)) {
                        $is_sticky.addClass(_has_fixed);
                    }
                } else {
                    if($is_sticky.hasClass(_has_fixed)) {
                        $is_sticky.removeClass(_has_fixed);
                    }
                }
            });
        }
	};

    // MenuOffset @v1.0
    NioApp.MenuOffset = function() {
        var $header = $('.' + _header), 
            _headerPT = parseInt($header.css("padding-top")), 
            _headerPB = parseInt($header.css("padding-bottom"));
        var _scrollOffset = $header.innerHeight() - _headerPT - _headerPB;
        return _scrollOffset;
    }

    // OnePageScroll @v1.0
    NioApp.OnePageScroll = function() {
        var _menuOffset = NioApp.MenuOffset();
        NioApp.coms.onResize.push(NioApp.MenuOffset);
        $body.scrollspy({ target: '.header-main', offset: _menuOffset });
        let trigger = document.querySelectorAll('a.menu-link[href*="#"]:not([href="#"])');
        trigger.forEach(function(element, index) {
            element.addEventListener("click", function(event) {
                event.preventDefault();
                if (location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') && location.hostname === this.hostname) {
                    let toHash = this.hash, toHashN = (this.hash.slice(1)) ? $('[name=' + this.hash.slice(1) + ']') : false;
                    let target = toHash.length ? document.querySelector(toHash) : toHashN;
                    let headerHT = _menuOffset;
                    window.scrollTo({
                        top: target.offsetTop - headerHT,
                        behavior: "smooth"
                    });
                }
            });
        });
    };

    // Form Validate @v1.0
    NioApp.Validate = function(elm, opt) {
        if ($(elm).exists()) {
            $(elm).each(function(){
                var def = {errorElement: "span"}, attr = (opt) ? extend(def, opt) : def;
                $(this).validate(attr);
            });
        }
    };

    NioApp.Validate.init = function() {
        NioApp.Validate('.form-validate', 
        {
            errorElement: "span",
            errorClass: "invalid",
            errorPlacement: function(error, element) {
                error.appendTo( element.parent() );
              }
        });
    }

    // BootStrap Extended
    NioApp.BS.ddfix = function(elm, exc) {
        var dd = (elm) ? elm : '.dropdown-menu',
            ex = (exc) ? exc : 'a:not(.clickable), button:not(.clickable), a:not(.clickable) *, button:not(.clickable) *';

        $(dd).on('click', function (e) {
            if(!$(e.target).is(ex)){ 
                e.stopPropagation();
                return;
            }
        });
        if(NioApp.State.isRTL){
            var $dMenu = $('.dropdown-menu');
            $dMenu.each(function(){
                var $self = $(this);
                if($self.hasClass('dropdown-menu-right') && !$self.hasClass('dropdown-menu-center')){
                    $self.prev('[data-toggle="dropdown"]').dropdown({
                        popperConfig: {
                            placement: 'bottom-start'
                        }
                    });
                }else if(!$self.hasClass('dropdown-menu-right') && !$self.hasClass('dropdown-menu-center')){
                    $self.prev('[data-toggle="dropdown"]').dropdown({
                        popperConfig: {
                            placement: 'bottom-end'
                        }
                    });
                }
            });
        }
    }

    // BootStrap Specific Tab Open
    NioApp.BS.tabfix = function(elm) {
        var tab = (elm) ? elm : '[data-toggle="modal"]';
        $(tab).on('click', function(){
            var _this = $(this), target = _this.data('target'), target_href = _this.attr('href'),
                tg_tab = _this.data('tab-target');

            var modal = (target) ? $body.find(target) : $body.find(target_href);
            if (tg_tab && tg_tab !=='#' && modal) {
                modal.find('[href="'+tg_tab+'"]').tab('show');
            } else if(modal) {
                var tabdef = modal.find('.nk-nav.nav-tabs');
                var link = $(tabdef[0]).find('[data-toggle="tab"]');
                $(link[0]).tab('show');
            }
        });
    }

    // Dark Mode Switch @since v2.0
    NioApp.ModeSwitch = function() {
        var toggle = $('.dark-switch');
        if($body.hasClass('dark-mode')){
            toggle.addClass('active');
        }else {
            toggle.removeClass('active');
        }
        toggle.on('click', function(e){
            e.preventDefault();
            $(this).toggleClass('active');
            $body.toggleClass('dark-mode');
        })
    }

    NioApp.Select2.init = function() {
        // NioApp.Select2('.select');
        NioApp.Select2('.form-select');
    };

    // Slick Slider @v1.0.1
    NioApp.Slick = function(elm, opt) {
        if($(elm).exists() && typeof($.fn.slick) === 'function') {
            $(elm).each(function(){
                var def = {
                        'prevArrow':'<div class="slick-arrow-prev"><a href="javascript:void(0);" class="slick-prev"><em class="icon ni ni-chevron-left"></em></a></div>',
                        'nextArrow':'<div class="slick-arrow-next"><a href="javascript:void(0);" class="slick-next"><em class="icon ni ni-chevron-right"></em></a></div>',
                        rtl: NioApp.State.isRTL
                    }, 
                    attr = (opt) ? extend(def, opt) : def;
                $(this).slick(attr);
            });
        }
    };

    // Slick Init @v1.0
    NioApp.Slider.init = function() {
        NioApp.Slick('.slider-init');
    };

    NioApp.Ovm = function () {
        var $elm_ovm = $('.nk-ovm'), $elm_ovm_mask = $('.nk-ovm[class*=mask]');
        if ($elm_ovm.exists()) {
            $elm_ovm.each(function () {
                if (!$(this).parent().hasClass('has-ovm')) { $(this).parent().addClass('has-ovm'); }
            });
        }
        if ($elm_ovm_mask.exists()) {
            $elm_ovm_mask.each(function () {
                if (!$(this).parent().hasClass('has-mask')) { $(this).parent().addClass('has-mask'); }
            });
        }
    };

    // Extra @v1.1
    NioApp.OtherInit = function() {
        NioApp.CurrentLink();
        NioApp.LinkOff('.is-disable');
        NioApp.ClassNavMenu();
        NioApp.SetHW('[data-height]', 'height');
        NioApp.SetHW('[data-width]', 'width');
    };

    // BootstrapExtend Init @v1.0
    NioApp.BS.init = function() {
        NioApp.BS.tooltip('[data-toggle="tooltip"]');
        NioApp.BS.popover('[data-toggle="popover"]');
        NioApp.BS.progress('[data-progress]');
        NioApp.BS.fileinput('.custom-file-input');
        NioApp.BS.modalfix();
        NioApp.BS.ddfix();
        NioApp.BS.tabfix();
    }

    // Addons @v1
    NioApp.Addons.Init = function() {
        NioApp.Select2.init();
        NioApp.Slider.init();
    };

    // Toggler @v1
    NioApp.TGL.init = function() {
        NioApp.TGL.content('.toggle');
        NioApp.TGL.expand('.toggle-expand'); 
        NioApp.TGL.expand('.toggle-opt', {toggle: false}); 
        NioApp.TGL.showmenu('.menu-toggler');
        NioApp.TGL.ddmenu('.menu-toggle', {self: 'menu-toggle', child: 'menu-sub' }); 
    };

    NioApp.BS.modalOnInit = function() {
        $('.modal').on('shown.bs.modal', function () {
            NioApp.Select2.init();
            NioApp.Validate.init();
        });
    };

    // Initial by default
    /////////////////////////////
    NioApp.init = function(){
        NioApp.coms.docReady.push(NioApp.OtherInit);
        NioApp.coms.docReady.push(NioApp.ColorBG);
        NioApp.coms.docReady.push(NioApp.ColorTXT);
        NioApp.coms.docReady.push(NioApp.TGL.init);
        NioApp.coms.docReady.push(NioApp.BS.init);
        NioApp.coms.docReady.push(NioApp.Validate.init);
        NioApp.coms.docReady.push(NioApp.headerSticky);
        NioApp.coms.docReady.push(NioApp.OnePageScroll);
        NioApp.coms.docReady.push(NioApp.Addons.Init);
        NioApp.coms.winLoad.push(NioApp.ModeSwitch);
        NioApp.coms.winLoad.push(NioApp.Ovm);
    }

    NioApp.init();

	return NioApp;
})(NioApp, jQuery);