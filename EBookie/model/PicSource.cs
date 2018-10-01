using System.Collections.ObjectModel;

namespace EBookie.model
{
    public class PicSource
    {
        public string PICNAME { get; set; }
        public string DESIGNER { get; set; }
        public string WEBSITE { get; set; }
        public string LICENCE { get; set; }
        public string SOURCE { get; set; }

        // Instanz des Windows (Klasse)
        static ObservableCollection<PicSource> list;

        public static ObservableCollection<PicSource> List
        {
            get { return list; }
            set { list = value; }
        }

        public PicSource(string picname, string designer, string website, string licence, string source)
        {
            PICNAME = picname;
            DESIGNER = designer;
            WEBSITE = website;
            LICENCE = licence;
            SOURCE = source;
        }

        public static void init_PicSources()
        {
            List = new ObservableCollection<PicSource>();
            List.Add(new PicSource("pack://siteoforigin:,,,/images/back.png", "Asher/Kyo-Tux", "http://kyo-tux.deviantart.com/", "CCA", "http://findicons.com/icon/68762/backward?id=287649"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/cancel.png", "Fatcow Web Hosting", "http://www.fatcow.com/free-icons", "CCA", "http://www.iconarchive.com/show/farm-fresh-icons-by-fatcow/cross-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/connection.png", "Oxygen Team", "", "Gnu/GPL", "http://findicons.com/icon/238270/network_wired?id=239561"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/delete.png", "TpdkDesign", "", "Gnu/GPL", "http://www.iconarchive.com/show/refresh-cl-icons-by-tpdkdesign.net/System-Recycle-Bin-Full-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/edit_s.png", "Everaldo/Yellowicon", "http://www.everaldo.com/", "Gnu/GPL", "http://www.everaldo.com/,Gnu/GPL,http://www.iconarchive.com/show/crystal-clear-icons-by-everaldo/Action-edit-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/english.png", "IconDrawer", "http://www.icondrawer.com/", "CCA", "http://www.iconarchive.com/show/flags-icons-by-icondrawer/United-Kingdo-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/execute.png", "Custom Icon Design", "http://www.customicondesign.com/", "Gnu/GPL", "http://www.customicondesign.com/,Gnu/GPL,http://www.iconarchive.com/show/flatastic-9-icons-by-custom-icon-design/Start-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/exit.png", "Icons8", "https://icons8.com/", "CCA", "http://www.iconarchive.com/show/windows-8-icons-by-icons8/User-Interface-Login-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/eye.png", "Custom Icon Design", "http://www.customicondesign.com/", "Gnu/GPL", "http://www.customicondesign.com/,GNU/GPL,http://www.iconarchive.com/show/flatastic-9-icons-by-custom-icon-design/Eye-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/failure.png", "VirtualLNK", "http://www.virtuallnk.com/", "CCA", "http://www.iconarchive.com/show/web-icons-by-virtuallnk/Delete-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/feedback.png", "Yusuke Kamiyamane", "http://p.yusukekamiyamane.com/", "CCA", "http://www.iconarchive.com/show/fugue-icons-by-yusuke-kamiyamane/megaphone-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/german.png", "GoSquared", "", "Gnu/GPL", "http://www.iconarchive.com/show/flag-icons-by-gosquared/Germany-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/home.png", "ipapun", "http://ipapun.deviantart.com/", "CCA", "http://findicons.com/icon/158565/home?id=158884"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/importSystems.png", "Aha-Soft Team", "http://www.small-icons.com/", "Gnu/GPL", "http://findicons.com/icon/219145/download"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/info_s.png", "Graphic Rating", "http://www.graphicrating.com/", "Gnu/GPL", "http://www.iconarchive.com/show/quartz-icons-by-graphicrating/Info-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/link.png", "Fatcow Web Hosting", "http://www.fatcow.com/free-icons", "CCA", "http://www.iconarchive.com/show/farm-fresh-icons-by-fatcow/link-add-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/lock.png", "Janik Baumgartner", "http://kinaj.com/", "CCA", "http://findicons.com/icon/455200/lock_closed"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/minus.png", "Pro Theme Design", "https://prothemedesign.com/", "CCA", "http://findicons.com/icon/168217/minus"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/new.png", "VisualPharm (Ivan Boyko)", "http://www.visualpharm.com/", "CCA", "http://findicons.com/icon/51052/new?id=51123"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/open.png", "AvoSoft", "http://www.avo-soft.com/", "CCA", "http://www.iconarchive.com/show/warm-toolbar-icons-by-avosoft/folder-open-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/plus.png", "Pro Theme Design", "https://prothemedesign.com/", "CCA", "http://findicons.com/icon/168198/add"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/reset.png", "GNOME icon artists", "https://www.gnome.org/", "Gnu/GPL", "http://findicons.com/icon/67286/gnome_edit_undo"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/save.png", "PixelMixer", "http://www.pixel-mixer.com/", "CCA", "http://findicons.com/icon/2986/save"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/settings.png", "Tango Desktop Project", "http://tango.freedesktop.org/", "Gnu/GPL", "http://findicons.com/icon/115538/preferences_system?id=382638"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/star.png", "Bill Lee", "http://www.customicondesign.com/", "Gnu/GPL", "http://findicons.com/icon/609125/star_full"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/success.png", "VirtualLNK", "http://www.virtuallnk.com/", "CCA", "http://www.iconarchive.com/show/web-icons-by-virtuallnk/Success-icon.html"));
            List.Add(new PicSource("pack://siteoforigin:,,,/images/upload.png", "Aha-Soft Team", "http://www.small-icons.com/", "Gnu/GPL", "http://findicons.com/icon/219131/upload?id=219290"));
        }
    }
}
