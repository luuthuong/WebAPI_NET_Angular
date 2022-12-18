
interface IPtSetting{
	model: number;
	title: number;
	view:{
		name: string;
		styles: {
			'font-size':string
		}
	}
}


export class CkEditorCommon {
	public static CkEditorCommonFunction(itemToolBar?: string) {
		const ckeditorConfig = {
			toolbar: {
				items: [],
				removeItems: [],
				viewportTopOffset: 30,
				shouldNotGroupWhenFull: true,
			},
			language: 'en',
			table: {
				contentToolbar: [
					'tableColumn',
					'tableRow',
					'mergeTableCells',
					'tableProperties',
					'tableCellProperties',
				],
			},
			image: {
				styles: ['alignLeft', 'alignCenter', 'alignRight'],
				toolbar: [
					'imageResize:25',
					'imageResize:50',
					'imageResize:75',
					'imageResize:original',
					'imageStyle:alignLeft',
					'imageStyle:alignCenter',
					'imageStyle:alignRight',
					'|',
					'imageTextAlternative',
					'|',
					'linkImage',
					'|',
					'imageMap',
					'|',
					'qmsFlowchart',
					'|',
					'qmsBpmn',
				],
				resizeOptions: [
					{
						name: 'imageResize:original',
						value: null,
						label: 'Original',
						icon: 'original',
					},
					{
						name: 'imageResize:25',
						value: 25,
						label: '25%',
						icon: 'small',
					},
					{
						name: 'imageResize:50',
						value: 50,
						label: '50%',
						icon: 'medium',
					},
					{
						name: 'imageResize:75',
						value: 75,
						label: '75%',
						icon: 'medium',
					},
				],
			},
			video: {
				styles: ['alignLeft', 'alignCenter', 'alignRight'],
				resizeUnit: '%',
				toolbar: [
					'videoResize',
					'|',
					'videoResize:25',
					'videoResize:50',
					'videoResize:75',
					'videoResize:original',
					'videoStyle:alignLeft',
					'videoStyle:alignCenter',
					'videoStyle:alignRight',
				],
				resizeOptions: [
					{
						name: 'videoResize:original',
						value: null,
						label: 'Original',
						icon: 'original',
					},
					{
						name: 'videoResize:25',
						value: 25,
						label: '25%',
						icon: 'small',
					},
					{
						name: 'videoResize:50',
						value: 50,
						label: '50%',
						icon: 'medium',
					},
					{
						name: 'videoResize:75',
						value: 75,
						label: '75%',
						icon: 'large',
					},
				],
			},
			media: {
				styles: ['alignLeft', 'alignCenter', 'alignRight'],
				resizeUnit: '%',
				toolbar: [
					'mediaResize',
					'|',
					'mediaResize:25',
					'mediaResize:50',
					'mediaResize:75',
					'mediaResize:original',
					'mediaStyle:alignLeft',
					'mediaStyle:alignCenter',
					'mediaStyle:alignRight',
				],
				resizeOptions: [
					{
						name: 'mediaResize:original',
						value: null,
						label: 'Original',
						icon: 'original',
					},
					{
						name: 'mediaResize:25',
						value: 25,
						label: '25%',
						icon: 'small',
					},
					{
						name: 'mediaResize:50',
						value: 50,
						label: '50%',
						icon: 'medium',
					},
					{
						name: 'mediaResize:75',
						value: 75,
						label: '75%',
						icon: 'large',
					},
				],
			},
			// Configure 'mediaEmbed' with Iframely previews.
			mediaEmbed: {
				// Previews are always enabled if there’s a provider for a URL (below regex catches all URLs)
				// By default `previewsInData` are disabled, but let’s set it to `false` explicitely to be sure
				previewsInData: true,
				styles: ['alignLeft', 'alignCenter', 'alignRight'],
				resizeUnit: '%',
				toolbar: [
					'mediaResize',
					'|',
					'mediaResize:25',
					'mediaResize:50',
					'mediaResize:75',
					'mediaResize:original',
					'mediaStyle:alignLeft',
					'mediaStyle:alignCenter',
					'mediaStyle:alignRight',
				],
				resizeOptions: [
					{
						name: 'mediaResize:original',
						value: null,
						label: 'Original',
						icon: 'original',
					},
					{
						name: 'mediaResize:25',
						value: 25,
						label: '25%',
						icon: 'small',
					},
					{
						name: 'mediaResize:50',
						value: 50,
						label: '50%',
						icon: 'medium',
					},
					{
						name: 'mediaResize:75',
						value: 75,
						label: '75%',
						icon: 'large',
					},
				],
				// providers: [
				//   {
				//     // hint: this is just for previews. Get actual HTML codes by making API calls from your CMS
				//     name: 'iframely previews',
				//     // Match all URLs or just the ones you need:
				//     url: /.+/,

				//     html: match => {
				//       const url = match[0];

				//       var iframeUrl = IFRAME_SRC + '?app=1&api_key=' + API_KEY + '&url=' + encodeURIComponent(url);
				//       // alternatively, use &key= instead of &api_key with the MD5 hash of your api_key
				//       // more about it: https://iframely.com/docs/allow-origins

				//       return (
				//         // If you need, set maxwidth and other styles for 'iframely-embed' class - it's yours to customize
				//         '<div class="iframely-embed">' +
				//         '<div class="iframely-responsive">' +
				//         `<iframe src="${iframeUrl}" ` +
				//         'frameborder="0" allow="autoplay; encrypted-media" allowfullscreen>' +
				//         '</iframe>' +
				//         '</div>' +
				//         '</div>'
				//       );
				//     }
				//   }
				// ]
			},
			link: {
				addTargetToExternalLinks: false,
				decorators: [
					{
						mode: 'manual',
						label: 'New window',
						attributes: {
							target: '_blank',
							manualTarget: true,
							url: 'url',
						},
					},
					{
						mode: 'manual',
						label: 'Topmost window',
						attributes: {
							target: '_top',
							manualTarget: true,
							url: 'url',
						},
					},
					{
						mode: 'manual',
						label: 'Same window',
						attributes: {
							target: '_self',
							manualTarget: true,
							url: 'url',
						},
					},
					{
						mode: 'manual',
						label: 'Parent window',
						attributes: {
							target: '_parent',
							manualTarget: true,
							url: 'url',
						},
					},
					{
						// alway put this one a the bottom
						mode: 'manual',
						label: 'Select range',
						attributes: {
							selectedRange: true,
						},
					},
				],
			},
			fontSize: {
				options: [
					this._generatePtSetting(8),
					this._generatePtSetting(9),
					this._generatePtSetting(10),
					this._generatePtSetting(11),
					this._generatePtSetting(12),
					this._generatePtSetting(14),
					this._generatePtSetting(16),
					this._generatePtSetting(18),
					this._generatePtSetting(20),
					this._generatePtSetting(22),
					this._generatePtSetting(24),
					this._generatePtSetting(26),
					this._generatePtSetting(28),
					this._generatePtSetting(36),
					this._generatePtSetting(48),
				],
			},
		};

		if(itemToolBar){
			const itemArr = itemToolBar.split(',');
			itemArr.forEach(x => {
				ckeditorConfig.toolbar.items = [...ckeditorConfig.toolbar.items, x as never]
			})
		}
		return ckeditorConfig;
	}

	private static _generatePtSetting(size: number): IPtSetting {
		return {
			model: size,
			title: size,
			view: {
				name: 'span',
				styles: {
					'font-size': `${size}pt`,
				},
			},
		};
	}
}
