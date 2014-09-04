package com.refractored.monodroidtoolkit.preferneces;


public class IntListPreference
	extends android.preference.ListPreference
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getPersistedString:(Ljava/lang/String;)Ljava/lang/String;:GetGetPersistedString_Ljava_lang_String_Handler\n" +
			"n_persistString:(Ljava/lang/String;)Z:GetPersistString_Ljava_lang_String_Handler\n" +
			"";
		mono.android.Runtime.register ("com.refractored.monodroidtoolkit.preferneces.IntListPreference, com.refractored.monodroidtoolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", IntListPreference.class, __md_methods);
	}


	public IntListPreference (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == IntListPreference.class)
			mono.android.TypeManager.Activate ("com.refractored.monodroidtoolkit.preferneces.IntListPreference, com.refractored.monodroidtoolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public IntListPreference (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == IntListPreference.class)
			mono.android.TypeManager.Activate ("com.refractored.monodroidtoolkit.preferneces.IntListPreference, com.refractored.monodroidtoolkit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public java.lang.String getPersistedString (java.lang.String p0)
	{
		return n_getPersistedString (p0);
	}

	private native java.lang.String n_getPersistedString (java.lang.String p0);


	public boolean persistString (java.lang.String p0)
	{
		return n_persistString (p0);
	}

	private native boolean n_persistString (java.lang.String p0);

	java.util.ArrayList refList;
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
