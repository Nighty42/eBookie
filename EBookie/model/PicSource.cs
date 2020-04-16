using System.Collections.ObjectModel;

namespace eBookie.model
{
    public class PicSource
    {
        public string PicName { get; set; }
        public string Designer { get; set; }
        public string Website { get; set; }
        public string License { get; set; }
        public string Source { get; set; }
        public static ObservableCollection<PicSource> List { get; set; } = new ObservableCollection<PicSource>()
        {
            new PicSource("pack://siteoforigin:,,,/images/back.png", "Asher/Kyo-Tux", "http://kyo-tux.deviantart.com/", "CCA", "http://findicons.com/icon/68762/backward?id=287649"),
            new PicSource("pack://siteoforigin:,,,/images/cancel.png", "Fatcow Web Hosting", "http://www.fatcow.com/free-icons", "CCA", "http://www.iconarchive.com/show/farm-fresh-icons-by-fatcow/cross-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/connection.png", "Oxygen Team", "", "Gnu/GPL", "http://findicons.com/icon/238270/network_wired?id=239561"),
            new PicSource("pack://siteoforigin:,,,/images/delete.png", "TpdkDesign", "", "Gnu/GPL", "http://www.iconarchive.com/show/refresh-cl-icons-by-tpdkdesign.net/System-Recycle-Bin-Full-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/edit_s.png", "Everaldo/Yellowicon", "http://www.everaldo.com/", "Gnu/GPL", "http://www.everaldo.com/,Gnu/GPL,http://www.iconarchive.com/show/crystal-clear-icons-by-everaldo/Action-edit-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/english.png", "IconDrawer", "http://www.icondrawer.com/", "CCA", "http://www.iconarchive.com/show/flags-icons-by-icondrawer/United-Kingdo-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/execute.png", "Custom Icon Design", "http://www.customicondesign.com/", "Gnu/GPL", "http://www.customicondesign.com/,Gnu/GPL,http://www.iconarchive.com/show/flatastic-9-icons-by-custom-icon-design/Start-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/exit.png", "Icons8", "https://icons8.com/", "CCA", "http://www.iconarchive.com/show/windows-8-icons-by-icons8/User-Interface-Login-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/eye.png", "Custom Icon Design", "http://www.customicondesign.com/", "Gnu/GPL", "http://www.customicondesign.com/,GNU/GPL,http://www.iconarchive.com/show/flatastic-9-icons-by-custom-icon-design/Eye-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/failure.png", "VirtualLNK", "http://www.virtuallnk.com/", "CCA", "http://www.iconarchive.com/show/web-icons-by-virtuallnk/Delete-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/feedback.png", "Yusuke Kamiyamane", "http://p.yusukekamiyamane.com/", "CCA", "http://www.iconarchive.com/show/fugue-icons-by-yusuke-kamiyamane/megaphone-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/german.png", "GoSquared", "", "Gnu/GPL", "http://www.iconarchive.com/show/flag-icons-by-gosquared/Germany-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/home.png", "ipapun", "http://ipapun.deviantart.com/", "CCA", "http://findicons.com/icon/158565/home?id=158884"),
            new PicSource("pack://siteoforigin:,,,/images/importSystems.png", "Aha-Soft Team", "http://www.small-icons.com/", "Gnu/GPL", "http://findicons.com/icon/219145/download"),
            new PicSource("pack://siteoforigin:,,,/images/info_s.png", "Graphic Rating", "http://www.graphicrating.com/", "Gnu/GPL", "http://www.iconarchive.com/show/quartz-icons-by-graphicrating/Info-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/link.png", "Fatcow Web Hosting", "http://www.fatcow.com/free-icons", "CCA", "http://www.iconarchive.com/show/farm-fresh-icons-by-fatcow/link-add-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/lock.png", "Janik Baumgartner", "http://kinaj.com/", "CCA", "http://findicons.com/icon/455200/lock_closed"),
            new PicSource("pack://siteoforigin:,,,/images/minus.png", "Pro Theme Design", "https://prothemedesign.com/", "CCA", "http://findicons.com/icon/168217/minus"),
            new PicSource("pack://siteoforigin:,,,/images/new.png", "VisualPharm (Ivan Boyko)", "http://www.visualpharm.com/", "CCA", "http://findicons.com/icon/51052/new?id=51123"),
            new PicSource("pack://siteoforigin:,,,/images/open.png", "AvoSoft", "http://www.avo-soft.com/", "CCA", "http://www.iconarchive.com/show/warm-toolbar-icons-by-avosoft/folder-open-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/plus.png", "Pro Theme Design", "https://prothemedesign.com/", "CCA", "http://findicons.com/icon/168198/add"),
            new PicSource("pack://siteoforigin:,,,/images/reset.png", "GNOME icon artists", "https://www.gnome.org/", "Gnu/GPL", "http://findicons.com/icon/67286/gnome_edit_undo"),
            new PicSource("pack://siteoforigin:,,,/images/save.png", "PixelMixer", "http://www.pixel-mixer.com/", "CCA", "http://findicons.com/icon/2986/save"),
            new PicSource("pack://siteoforigin:,,,/images/settings.png", "Tango Desktop Project", "http://tango.freedesktop.org/", "Gnu/GPL", "http://findicons.com/icon/115538/preferences_system?id=382638"),
            new PicSource("pack://siteoforigin:,,,/images/star.png", "Bill Lee", "http://www.customicondesign.com/", "Gnu/GPL", "http://findicons.com/icon/609125/star_full"),
            new PicSource("pack://siteoforigin:,,,/images/success.png", "VirtualLNK", "http://www.virtuallnk.com/", "CCA", "http://www.iconarchive.com/show/web-icons-by-virtuallnk/Success-icon.html"),
            new PicSource("pack://siteoforigin:,,,/images/upload.png", "Aha-Soft Team", "http://www.small-icons.com/", "Gnu/GPL", "http://findicons.com/icon/219131/upload?id=219290")
        };

        public PicSource(string picname, string designer, string website, string licence, string source)
        {
            PicName = picname;
            Designer = designer;
            Website = website;
            License = licence;
            Source = source;
        }
    }
}
