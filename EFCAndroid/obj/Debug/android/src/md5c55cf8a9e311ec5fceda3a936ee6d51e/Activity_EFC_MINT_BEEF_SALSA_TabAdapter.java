package md5c55cf8a9e311ec5fceda3a936ee6d51e;


public class Activity_EFC_MINT_BEEF_SALSA_TabAdapter
	extends android.support.v4.app.FragmentPagerAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getItem:(I)Landroid/support/v4/app/Fragment;:GetGetItem_IHandler\n" +
			"n_getPageTitle:(I)Ljava/lang/CharSequence;:GetGetPageTitle_IHandler\n" +
			"";
		mono.android.Runtime.register ("EFCAndroid.clicked_menu.Activity_EFC_MINT_BEEF_SALSA+TabAdapter, EFCAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Activity_EFC_MINT_BEEF_SALSA_TabAdapter.class, __md_methods);
	}


	public Activity_EFC_MINT_BEEF_SALSA_TabAdapter (android.support.v4.app.FragmentManager p0)
	{
		super (p0);
		if (getClass () == Activity_EFC_MINT_BEEF_SALSA_TabAdapter.class)
			mono.android.TypeManager.Activate ("EFCAndroid.clicked_menu.Activity_EFC_MINT_BEEF_SALSA+TabAdapter, EFCAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Support.V4.App.FragmentManager, Xamarin.Android.Support.Fragment, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", this, new java.lang.Object[] { p0 });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public android.support.v4.app.Fragment getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native android.support.v4.app.Fragment n_getItem (int p0);


	public java.lang.CharSequence getPageTitle (int p0)
	{
		return n_getPageTitle (p0);
	}

	private native java.lang.CharSequence n_getPageTitle (int p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
