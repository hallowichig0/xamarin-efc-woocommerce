package md5c55cf8a9e311ec5fceda3a936ee6d51e;


public class Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"";
		mono.android.Runtime.register ("EFCAndroid.clicked_menu.Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD, EFCAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD.class, __md_methods);
	}


	public Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD ()
	{
		super ();
		if (getClass () == Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD.class)
			mono.android.TypeManager.Activate ("EFCAndroid.clicked_menu.Activity_EFC_ROASTED_CHICKEN_FUNKY_SALAD, EFCAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);

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
