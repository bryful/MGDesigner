# MGDesigner

僕はモニタデザインする時、ラフは方眼紙に鉛筆で書いてスマホで写真撮ってPCに取り込みそれを元にやってます。
最近それが余りにも面倒に感じてきたので作り始めたのがこれです。<br>
<br>
Visual Studio のフォームデザイナはかなり優秀なので、これを使ってデザインラフ作れないかなと。<br>
<br>
まぁAfter Effectsのスクリプトのダイアログデザインツールでも使った事あるので簡単に作れるなぁと。<br>
<br>
とりあえず今日一日で作ったのでパーツがまだ少ないです。


# 使い方
visual studio 2022をインストールします。<br>
<br>
VSでgithubからこれをクローンして、おもむろにテンプレートに保存し直します。<br>
<br>
そして新規プロジェクトで作ったテンプレートでプロジェクトを作れば後はお好きにできます。<br>
<br>
とりあえず一回ビルドした後、MainForm.csをデザイナーで開きます（あぶるクリックです）
旨くいけばスールパレットに専用コントロールが表示されるはずです。MGから始まる物です。
<br>
MGコントロールをMainFormへドラッグして登録します。<br>
プロパティパネルの"__MG"カテゴリにあるMGFormプロパティでMainFormを選べばMGColorsパレットで色を変えることが出来ます。
その他のパレメータは"_MG"カテゴリにまとめてあります。<br>
<br>
ちょっとVSのデザイナのことを知らないと大変ですがプログラムと違い覚えることはそんなに多くありません。


画像を書き出したい時は、まずデバッグ実行します。表示されたウインドウを右クリックすると
メニューが出ますので、それを実行すれば画像が書き出しされます。<br>

Partsは各コントロール毎にpngファイルが出力されます。Mixは合成されたpngが書き出されます。


# Dependency
Visual studio 2022 C#<br>


# License

This software is released under the MIT License, see LICENSE

# Authors

bry-ful(Hiroshi Furuhashi)<br>
twitter:bryful<br>
bryful@gmail.com<br>

