   M S B A M L   `   `   `  ����  OficiosPlenos    OficiosPlenos.SecGeneral   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	   -   5          � Title$  Mensajes SGA��5   	   $	��520��5   	   $	��400��5   	    � Icon$ Resources/postal.png��5   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��20,20,20,45q�6   $��Stretch=�5      $��Stretch=�5      $��Oficio Enviado��5      .��5      � .+�5      �� $��	10,26,0,0q�6   $
��Left=�5      $	��Top=�5      $��Oficio:��5      �� 5      -   5         ��Name$ TxtOficioEnviado��5      $	��135��5      $��23��5      $��	59,26,0,0q�5      $
��Left=�5      $	��Top=�5        �� TextWrapping$
 Wrap=�5#      ��5!      �� *	OficioSga+ �� Mode$ TwoWay=�5#      �� 5$      $��	10,71,0,0q�6   $
��Left=�5%      $	��Top=�5&      $��Fecha de envio:��5'      ,  &Telerik.Windows.Controls.RadDatePicker  5)      -   5          Name$ DpFechaEnvio��5)   (   $	��146��5*   (   $��
10,102,0,0q�5+   (   $
��Left=�5,   (   $	��Top=�5-   (   0  *Telerik.Windows.Controls.RadDateTimePicker	   SelectedValue	 5.   (   �� *FEnvioOfSga+�� 5/      -   5        
 ��Name$
 BtnVerOficio��5/      $	��146��50      $��
10,159,0,0q�51      $
��Left=�52      $	��Top=�53      $��Ver oficio enviado��55      �� 56      -   5        $
 BtnGenerarOficio��56      $	��146��57      $��
10,159,0,0q�58      $
��Left=�59      $	��Top=�5:      $��Generar Oficio��5<      5>      5?      �� 5C   
   $��1��6   $��20,20,20,45q�5D      $��Stretch=�5E      $��Stretch=�5F      $��	Respuesta��5G      .��5H      � .+�5I      �� $��	10,24,0,0q�6   $
��Left=�5J      $	��Top=�5K      $��Oficio:��5L      �� 5M      -   5        $ TxtRespuesta��5M      $	��135��5N      $��23��5O      $��	59,24,0,0q�5P      $
��Left=�5Q      $	��Top=�5R      $
 Wrap=�5U      ��5S      �� *OficioRespuestaSga+$ TwoWay=�5U      �� 5V      $��
10,115,0,0q�6   $
��Left=�5W      $	��Top=�5X      $��Fecha de respuesta:��5Y        5Z      -   5        $ DpRespuesta��5Z   (   $	��169��5[   (   $��
10,141,0,0q�5\   (   $
��Left=�5]   (   $	��Top=�5^   (   	 5_   (   �� *FRespuestaSga+�� 5`      $��
10,180,0,0q�6   $
��Left=�5a      $	��Top=�5b      $��Archivo respuesta:��5c      �� 5d      -   5        $ TxtFileRespuesta��5d      $	��154��5e      $��23��5f      $��
10,206,0,0q�5g      $
��Left=�5h      $	��Top=�5i      {�.  ��5k      �� *OfRespuestaSgaFilePath+$ TwoWay=��� 5m      -	   5        $
 BtnFileRespuesta��5m      $��25��5n      $��169,206,0,0q�5o      $
��Left=�5p      $	��Top=�5q      $	��...��5s      �� 5t      -
   5         ��Name$ ChkContradiccion��5t      $��	10,75,0,0q�5u      $
��Left=�5v      $	��Top=�5w      $�� ¿Existe contradicción?��5x       d� 	IsChecked 5y      �� *ExisteContradiccion+�� 5z      -   5        $
 BtnVerRespuesta��5z      $	��107��5{      $��
10,245,0,0q�5|      $
��Left=�5}      $	��Top=�5~      $��Ver Respuesta��5�      5�      5�      �� 5�   
   -   5        $
 BtnCancelar��5�      $��1��5�      $��75��5�      $��	0,0,20,10q�5�      $��Right=�5�      $��Bottom=�5�      $��Cancelar��5�      �� 5�   
   -   5        $
 
BtnGuardar��5�      $��1��5�      $��75��5�      $��
0,0,100,10q�5�      $��Right=�5�      $��Bottom=�5�      $��Guardar��5�      5�      5�      