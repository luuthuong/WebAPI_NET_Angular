export class APP_ROUTE{
    public static readonly AUTH ='auth';
    public static readonly HOME = 'home';
    public static readonly BLOG = 'blog';
    public static readonly FILEMEDIA ='filemedia';
    public static readonly LANDING = 'landing';
    public static readonly SHOP ='shop';
    public static readonly USER ='user';
}

export class AUTH_ROUTE{
    public static readonly LOGIN ='login';
    public static readonly FORGOTPWD = 'forgot'
}

export class HOME_ROUTE{

}

export class BLOG_ROUTE{
    public static readonly OVERVIEW = 'overview';
    public static readonly DETAIL = ':id';
    public static readonly SEARCH = 'search';
    public static readonly EDIT = 'edit/:id';
    public static readonly CREATE = 'create';
}

export class FILEMEDIA_ROUTE{

}

export class LANDING_ROUTE{

}