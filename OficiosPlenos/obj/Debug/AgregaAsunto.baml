   M S B A M L   `   `   `  ����  OficiosPlenos     OficiosPlenos.AgregaAsunto   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   p lTelerik.Windows.Controls.RibbonView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n	 jTelerik.Windows.Controls.GridView, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2014.2.729.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	   -   5          � Title$  AgregaAsunto��5   	   $��784.776��5   	   $	��650��5   	    � Icon$ Resources/postal.png��5   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� $��	30,29,0,0q�6   $
��Left=�5      $	��Top=�5      $"��Pleno de Circuito que emite:��5      �� 5   
   -   5         ��Name$ 	CbxPlenos��5      $	��367��5      $��	30,60,0,0q�5      $
��Left=�5      $	��Top=�5       �� DisplayMemberPath$ OrganismoDesc��5       �� SelectedValuePath$ IdOrganismo��5      ��5      �� 5      �� 5   
   $��
30,102,0,0q�6   $
��Left=�5      $	��Top=�5      $��Secretario encargado:��5      �� 5   
   -   5         ��Name$ TxtSecretario��5      $	��362��5      $��23��5       $��
35,133,0,0q�5!      $
��Left=�5"      $	��Top=�5#      {�.   �� TextWrapping$
 Wrap=�5'      ��5%      �� *Encargado.Completo+	 �� Mode$	 TwoWay=�5'      �� 5(   
   $	��233��6   $��97��5)      $��
35,186,0,0q�5*      $
��Left=�5+      $	��Top=�5,      $��Contradicción de Tesis��5-      
 J� RenderTransformOrigin$
 0.5,0.5&�5.      .��5/      � .+�50      �� $��	44,10,0,0q�6   $
��Left=�51      $	��Top=�52      $��Número��53      �� 54      -   5        $ TxtNumAsunto��54      $��54��55      $��23��56      $��	44,36,0,0q�57      $
��Left=�58      $	��Top=�59      $
 Wrap=�5<      ��5;      �� *	NumAsunto+5<      �� 5?      $��
160,10,0,0q�6   $
��Left=�5@      $	��Top=�5A      $
��Año��5B      �� 5C      -   5        $ TxtYear��5C      $��54��5D      $��23��5E      $��
150,36,0,0q�5F      $
��Left=�5G      $	��Top=�5H      $
 Wrap=�5K      ��5J      �� *
AnioAsunto+5K      �� 5L      $��
116,29,0,0q�6   $
��Left=�5M      $	��Top=�5N      $��/��5O      $��17(�5P      $
��Bold"�5Q      5R      5S      �� 5T   
   $	��228��6   $��35,309,35,0q�5U      $��Stretch=�5V      $	��Top=�5W      $��Acuerdo admisorioLabel��5X      .��5Y      � .+�5Z      �� $��	23,10,0,0q�6   $
��Left=�5[      $	��Top=�5\      $��Oficio de admisión:��5]      �� 5^      -   5        $ TxtOficioAd��5^      $	��215��5_      $��23��5`      $��	23,41,0,0q�5a      $
��Left=�5b      $	��Top=�5c      $
 Wrap=�5g      ��5d      �� *OficioAdmision+$	 TwoWay=�5g      �� 5h      $��	23,72,0,0q�6   $
��Left=�5i      $	��Top=�5j      $%��Fecha de recepción del oficio:��5k      ,  &Telerik.Windows.Controls.RadDatePicker  5m      -   5          Name$ 	DtpOficio��5m   (   $	��215��5n   (   $��
23,103,0,0q�5o   (   $
��Left=�5p   (   $	��Top=�5q   (   {�.  0  *Telerik.Windows.Controls.RadDateTimePicker   SelectedValue 5s   (   �� *FechaOficioAdmin+�� 5t      $��
23,137,0,0q�6   $
��Left=�5u      $	��Top=�5v      $��Archivo del oficio:��5w      �� 5x      -   5        $ TxtFilePath��5x      $	��259��5y      $��23��5z      $��
23,168,0,0q�5{      $
��Left=�5|      $	��Top=�5}      {�.  $
 Wrap=�5�      ��5      �� *OficioFilePath+$	 TwoWay=�5�      �� 5�      -	   5         ��Name$ 	BtnOficio��5�      $��44��5�      $��287,168,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $	��...��5�      {�.  5�      �� 5�      $��
380,40,0,0q�6   $
��Left=�5�      $	��Top=�5�      $��Correo electrónico��5�      $
��Bold"�5�      �� 5�      $��
380,72,0,0q�6   $
��Left=�5�      $	��Top=�5�      $%��Fecha de recepción del correo:��5�        5�      -
   5        $ 	DtpCorreo��5�   (   $	��227��5�   (   $��380,103,0,0q�5�   (   $
��Left=�5�   (   $	��Top=�5�   (    5�   (   �� *FechaCorreo+5�   (   �� 5�      $��380,137,0,0q�6   $
��Left=�5�      $	��Top=�5�      $��Archivo del correo:��5�      �� 5�      -   5        $ TxtCorreoFilePath��5�      $	��250��5�      $��23��5�      $��380,168,0,0q�5�      $
��Left=�5�      $	��Top=�5�      {�.  $
 Wrap=�5�      ��5�      �� *CorreoFilePath+$	 TwoWay=�5�      �� 5�      -   5        $ BtnCorreoFile��5�      $��44��5�      $��635,168,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $	��...��5�      {�.  5�      5�      5�      �� 5�   
   -   5        $ BtnCancelar��5�      $��75��5�      $��667,569,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Cancelar��5�      �� 5�   
   -   5        $ 
BtnGuardar��5�      $��75��5�      $��587,569,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $��Guardar��5�      �� 5�   
   $��395,182,0,0q�6   $
��Left=�5�      $	��Top=�5�      $��Tema:��5�      �� 5�   
   -   5        $ TxtTema��5�      $	��347��5�      $��96��5�      $��395,208,0,0q�5�      $
��Left=�5�      $	��Top=�5�      $
 Wrap=�5�      ��5�      �� *Tema+$	 TwoWay=�5�      5�      5�      