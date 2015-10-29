<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CPanel.aspx.cs" Inherits="WebApplication1.CPanel" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Control Panel</title>
    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <link href="css/enaveed.css" rel="stylesheet" />

    <script>
        $(function () {
            $("#accordion").accordion();
        });
    </script>
    <script>
        $(function () {
            $("#accordion").accordion({
                event: "click hoverintent"
            });
        });

        /*
         * hoverIntent | Copyright 2011 Brian Cherne
         * http://cherne.net/brian/resources/jquery.hoverIntent.html
         * modified by the jQuery UI team
         */
        $.event.special.hoverintent = {
            setup: function () {
                $(this).bind("mouseover", jQuery.event.special.hoverintent.handler);
            },
            teardown: function () {
                $(this).unbind("mouseover", jQuery.event.special.hoverintent.handler);
            },
            handler: function (event) {
                var currentX, currentY, timeout,
                  args = arguments,
                  target = $(event.target),
                  previousX = event.pageX,
                  previousY = event.pageY;

                function track(event) {
                    currentX = event.pageX;
                    currentY = event.pageY;
                };

                function clear() {
                    target
                      .unbind("mousemove", track)
                      .unbind("mouseout", clear);
                    clearTimeout(timeout);
                }

                function handler() {
                    var prop,
                      orig = event;

                    if ((Math.abs(previousX - currentX) +
                        Math.abs(previousY - currentY)) < 7) {
                        clear();

                        event = $.Event("hoverintent");
                        for (prop in orig) {
                            if (!(prop in event)) {
                                event[prop] = orig[prop];
                            }
                        }
                        // Prevent accessing the original event since the new event
                        // is fired asynchronously and the old event is no longer
                        // usable (#6028)
                        delete event.originalEvent;

                        target.trigger(event);
                    } else {
                        previousX = currentX;
                        previousY = currentY;
                        timeout = setTimeout(handler, 100);
                    }
                }

                timeout = setTimeout(handler, 100);
                target.bind({
                    mousemove: track,
                    mouseout: clear
                });
            }
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%; height: 50px; background-color: chocolate;">
            <a href="">Home</a>
        </div>
        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Control Panel" Font-Bold="True" Font-Size="XX-Large" Theme="Mulberry"></dx:ASPxLabel>

        <div id="accordion" style="width: 200px;">

            <h3>Posts</h3>

            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton1" runat="server" Text="All Posts" Theme="SoftOrange" Cursor="pointer">
                        <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton2" runat="server" Text="Create Post" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/createpostHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/createpostHover.png" Repeat="NoRepeat" />
                        </HoverStyle>

                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton3" runat="server" Text="Post Categories" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/Categories.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/Categories.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>


            <h3>Pages</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton4" runat="server" Text="All Pages" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton5" runat="server" Text="Create Page" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>

                </p>
            </div>

            <h3>Gallery</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton6" runat="server" Text="View Gallery" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>

                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton7" runat="server" Text="Upload Media" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>

            <h3>Comments</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton8" runat="server" Text="View All Comments" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton9" runat="server" Text="View New Comments" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>

            <h3>Appearance</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton10" runat="server" Text="Themes" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton11" runat="server" Text="Widgets" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton12" runat="server" Text="Color Scheme" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>

            <h3>Plugins</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton13" runat="server" Text="Installed Plugins" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton14" runat="server" Text="Install New Plugin" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>

            <h3>Users</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton15" runat="server" Text="View All Users" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton16" runat="server" Text="Edit a User" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton17" runat="server" Text="View Your Profile" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>

            <h3>Settings</h3>
            <div>
                <p>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton18" runat="server" Text="General" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton19" runat="server" Text="Posts & Pages" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                    <dx:ASPxButton CssClass="cpanelSidebarButtons" ID="ASPxButton20" runat="server" Text="Gallery" Theme="SoftOrange" Cursor="pointer">
                    <PressedStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </PressedStyle>
                        <HoverStyle BackColor="#1C94C4" Font-Bold="True" Font-Size="X-Large">
                            <BackgroundImage HorizontalPosition="left" ImageUrl="~/Images/AllpostsHover.png" Repeat="NoRepeat" />
                        </HoverStyle>
                    </dx:ASPxButton>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
