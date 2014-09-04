using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;

namespace nav
{
    [Activity(Label = "nav", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private MyActionBarDrawerToggle m_DrawerToggle;
        private string m_DrawerTitle;
        private string m_Title;

        private DrawerLayout m_Drawer;
        private ListView m_DrawerList;
        private static readonly string[] Sections = new[]
            {
                "one ", "two"
            };


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            this.m_Title = this.m_DrawerTitle = this.Title;

            this.m_Drawer = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this.m_DrawerList = this.FindViewById<ListView>(Resource.Id.left_drawer);

            this.m_DrawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.item_menu, Sections);

            this.m_DrawerList.ItemClick += (sender, args) => ListItemClicked(args.Position);


            this.m_Drawer.SetDrawerShadow(Resource.Drawable.icon, (int)GravityFlags.Start);



            //DrawerToggle is the animation that happens with the indicator next to the actionbar
            this.m_DrawerToggle = new MyActionBarDrawerToggle(this, this.m_Drawer,
                                                      Resource.Drawable.icon,
                                                      Resource.String.drawer_open,
                                                      Resource.String.drawer_close);

            //Display the current fragments title and update the options menu
            this.m_DrawerToggle.DrawerClosed += (o, args) =>
            {
                this.ActionBar.Title = this.m_Title;
                this.InvalidateOptionsMenu();
            };

            //Display the drawer title and update the options menu
            this.m_DrawerToggle.DrawerOpened += (o, args) =>
            {
                this.ActionBar.Title = this.m_DrawerTitle;
                this.InvalidateOptionsMenu();
            };

            //Set the drawer lister to be the toggle.
            this.m_Drawer.SetDrawerListener(this.m_DrawerToggle);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.SetHomeButtonEnabled(true);


        }
        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            this.m_DrawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            this.m_DrawerToggle.OnConfigurationChanged(newConfig);
        }

        // Pass the event to ActionBarDrawerToggle, if it returns
        // true, then it has handled the app icon touch event
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (this.m_DrawerToggle.OnOptionsItemSelected(item))
                return true;

            return base.OnOptionsItemSelected(item);
        }

        private void ListItemClicked(int position)
        {
            Fragment fragment = null;
            switch (position)
            {
                case 0:
                    fragment = new Fragment1();
                    break;
                case 1:
                    fragment = new Fragment2();
                    break;
            }

            FragmentManager.BeginTransaction()
                .Replace(Resource.Id.content_frame, fragment)
                ;

            this.m_DrawerList.SetItemChecked(position, true);
            ActionBar.Title = this.m_Title = Sections[position];
            this.m_Drawer.CloseDrawer(this.m_DrawerList);
        }





        public override bool OnPrepareOptionsMenu(IMenu menu)
        {

            var drawerOpen = this.m_Drawer.IsDrawerOpen(this.m_DrawerList);
            //when open don't show anything
            for (int i = 0; i < menu.Size(); i++)
                menu.GetItem(i).SetVisible(!drawerOpen);


            return base.OnPrepareOptionsMenu(menu);
        }
    }
}

